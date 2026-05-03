using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Formula_1
{
    // "static" клас — не можна створити через "new DatabaseHelper()".
    // Всі методи викликаються напряму: DatabaseHelper.GetTeams(), DatabaseHelper.AddTeam() і т.д.
    // "internal" — клас доступний тільки всередині цього проекту.
    internal static class DatabaseHelper
    {
        // ─── Шляхи до файлів ────────────────────────────────────────────────

        // Властивість (property) — це як поле, але значення обчислюється кожного разу.
        // "get" означає: "виконай цей код і поверни результат кожного разу, коли хтось читає".
        // Application.StartupPath — папка, де знаходиться .exe файл програми.
        // Path.Combine — правильно з'єднує частини шляху (додає '\' між ними).
        public static string DatabasePath
        {
            get
            {
                return Path.Combine(Application.StartupPath, "Assets", "Database", "formula1.db");
            }
        }

        // Шлях до папки з логотипами команд
        public static string LogosFolderPath
        {
            get { return Path.Combine(Application.StartupPath, "Assets", "Database", "Logos"); }
        }

        // Шлях до папки з фото пілотів
        public static string PhotosFolderPath
        {
            get { return Path.Combine(Application.StartupPath, "Assets", "Database", "Photos"); }
        }

        // Рядок підключення до SQLite-бази.
        // "Data Source" — шлях до файлу .db, "Version=3" — версія SQLite (завжди 3).
        // "private" — тільки цей клас може його використовувати.
        private static string ConnectionString
        {
            get { return "Data Source=" + DatabasePath + ";Version=3;"; }
        }

        // ─── Ініціалізація ────────────────────────────────────────────────────

        // Головний метод для запуску БД. Викликається один раз при відкритті форми.
        // Створює папку і файл БД, якщо вони ще не існують.
        public static void InitializeDatabase()
        {
            // Path.GetDirectoryName — повертає папку з шляху до файлу
            // Наприклад: "Assets\Database\formula1.db" -> "Assets\Database"
            string dbDir = Path.GetDirectoryName(DatabasePath);

            // Якщо папка не існує — створюємо її (і всі батьківські папки)
            if (!Directory.Exists(dbDir))
                Directory.CreateDirectory(dbDir);

            // Запам'ятовуємо: чи БД вже існувала до цього
            bool isNew = !File.Exists(DatabasePath);

            // "using" — гарантує, що з'єднання закриється автоматично (навіть якщо буде помилка).
            // Це замінює пару conn.Open() ... conn.Close().
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();             // відкриваємо з'єднання з файлом БД

                CreateTables(conn);      // створюємо таблиці (якщо ще немає)

                if (isNew)
                    SeedData(conn);      // якщо БД нова — заповнюємо початковими даними
            }
            // тут conn.Dispose() (= conn.Close()) викликається автоматично
        }

        // Створює таблиці Teams і Drivers, якщо вони ще не існують.
        // "IF NOT EXISTS" — безпечна команда: не дає помилку якщо таблиця вже є.
        private static void CreateTables(SQLiteConnection conn)
        {
            // SQL-команда для створення таблиці команд.
            // INTEGER PRIMARY KEY AUTOINCREMENT — унікальний номер, що збільшується автоматично.
            // NOT NULL — поле обов'язкове (не може бути порожнім).
            // DEFAULT 0 — значення за замовчуванням якщо не вказати.
            string sqlTeams = @"
                CREATE TABLE IF NOT EXISTS Teams (
                    team_id            INTEGER PRIMARY KEY AUTOINCREMENT,
                    team_name          TEXT    NOT NULL,
                    team_country       TEXT    NOT NULL,
                    team_founded       INTEGER NOT NULL,
                    team_championships INTEGER NOT NULL DEFAULT 0,
                    team_logo_file     TEXT    NOT NULL DEFAULT ''
                );";

            // SQL-команда для створення таблиці пілотів.
            // FOREIGN KEY (team_id) REFERENCES Teams(team_id) — зовнішній ключ:
            //   team_id у Drivers посилається на team_id у Teams.
            // ON DELETE CASCADE — якщо видалити команду, всі її пілоти видаляться автоматично.
            string sqlDrivers = @"
                CREATE TABLE IF NOT EXISTS Drivers (
                    driver_id          INTEGER PRIMARY KEY AUTOINCREMENT,
                    team_id            INTEGER NOT NULL,
                    driver_name        TEXT    NOT NULL,
                    driver_number      INTEGER NOT NULL,
                    driver_nationality TEXT    NOT NULL,
                    driver_wins        INTEGER NOT NULL DEFAULT 0,
                    driver_points      REAL    NOT NULL DEFAULT 0,
                    driver_photo_file  TEXT    NOT NULL DEFAULT '',
                    FOREIGN KEY (team_id) REFERENCES Teams(team_id) ON DELETE CASCADE
                );";

            using (SQLiteCommand cmd = conn.CreateCommand())
            {
                // PRAGMA — спеціальна команда налаштування SQLite.
                // foreign_keys = ON — вмикає підтримку зовнішніх ключів
                // (у SQLite вони вимкнені за замовчуванням!).
                cmd.CommandText = "PRAGMA foreign_keys = ON;";
                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlTeams;
                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlDrivers;
                cmd.ExecuteNonQuery();
            }
        }

        // ─── Початкові дані (сезон 2026) ────────────────────────────────────

        // Заповнює БД початковими даними при першому запуску.
        private static void SeedData(SQLiteConnection conn)
        {
            // 11 команд Formula 1 — сезон 2026
            // Параметри: (з'єднання, назва, країна, рік заснування, чемпіонства, файл логотипу)
            InsertTeam(conn, "Red Bull Racing", "Austria", 2005, 6,  "redbull.png");
            InsertTeam(conn, "Ferrari",         "Italy",   1950, 16, "ferrari.png");
            InsertTeam(conn, "McLaren",         "UK",      1963, 9,  "mclaren.png");
            InsertTeam(conn, "Mercedes AMG",    "Germany", 2010, 8,  "mercedes.png");
            InsertTeam(conn, "Aston Martin",    "UK",      2021, 0,  "astonmartin.png");
            InsertTeam(conn, "Alpine",          "France",  2021, 2,  "alpine.png");
            InsertTeam(conn, "Williams",        "UK",      1977, 9,  "williams.png");
            InsertTeam(conn, "Haas",            "USA",     2016, 0,  "haas.png");
            InsertTeam(conn, "Audi F1",         "Germany", 1993, 0,  "audi.png");
            InsertTeam(conn, "Racing Bulls",    "Italy",   2006, 0,  "racingbulls.png");
            InsertTeam(conn, "Cadillac F1",     "USA",     2026, 0,  "cadillac.png");

            // Пілоти сезону 2026 (по 2 на команду)
            // Параметри: (з'єднання, id команди, ім'я, номер, нац., перемоги, очки, файл фото)

            // Red Bull Racing (team_id = 1)
            InsertDriver(conn, 1, "Max Verstappen",    1,  "Dutch",          67, 78.0, "verstappen.png");
            InsertDriver(conn, 1, "Isack Hadjar",       6, "French",           0, 12.0, "hadjar.png");
            // Ferrari (team_id = 2)
            InsertDriver(conn, 2, "Charles Leclerc",   16, "Monegasque",     12, 90.0, "leclerc.png");
            InsertDriver(conn, 2, "Lewis Hamilton",    44, "British",        105, 82.0, "hamilton.png");
            // McLaren (team_id = 3)
            InsertDriver(conn, 3, "Lando Norris",       4, "British",          9, 85.0, "norris.png");
            InsertDriver(conn, 3, "Oscar Piastri",     81, "Australian",       6, 68.0, "piastri.png");
            // Mercedes AMG (team_id = 4)
            InsertDriver(conn, 4, "George Russell",    63, "British",          4, 55.0, "russell.png");
            InsertDriver(conn, 4, "Kimi Antonelli",    12, "Italian",          0, 32.0, "antonelli.png");
            // Aston Martin (team_id = 5)
            InsertDriver(conn, 5, "Fernando Alonso",   14, "Spanish",         32, 38.0, "alonso.png");
            InsertDriver(conn, 5, "Lance Stroll",      18, "Canadian",         0, 10.0, "stroll.png");
            // Alpine (team_id = 6)
            InsertDriver(conn, 6, "Pierre Gasly",      10, "French",           1, 22.0, "gasly.png");
            InsertDriver(conn, 6, "Jack Doohan",        7, "Australian",       0,  4.0, "doohan.png");
            // Williams (team_id = 7)
            InsertDriver(conn, 7, "Carlos Sainz",      55, "Spanish",          5, 45.0, "sainz.png");
            InsertDriver(conn, 7, "Alexander Albon",   23, "Thai",             0, 16.0, "albon.png");
            // Haas (team_id = 8)
            InsertDriver(conn, 8, "Esteban Ocon",      31, "French",           1,  8.0, "ocon.png");
            InsertDriver(conn, 8, "Oliver Bearman",    87, "British",          0,  6.0, "bearman.png");
            // Audi F1 (team_id = 9)
            InsertDriver(conn, 9, "Nico Hulkenberg",   27, "German",           0, 14.0, "hulkenberg.png");
            InsertDriver(conn, 9, "Gabriel Bortoleto",  5, "Brazilian",        0,  2.0, "bortoleto.png");
            // Racing Bulls (team_id = 10)
            InsertDriver(conn, 10, "Liam Lawson",      30, "New Zealander",    0, 28.0, "lawson.png");
            InsertDriver(conn, 10, "Arvid Lindblad",   41, "British",          0,  0.0, "lindblad.png");
            // Cadillac F1 (team_id = 11)
            InsertDriver(conn, 11, "Sergio Perez",    11, "Mexican",          6, 45.0, "perez.png");
            InsertDriver(conn, 11, "Valtteri Bottas", 77, "Finnish",          10, 60.0, "bottas.png");
        }

        // Допоміжний метод: вставляє один запис у таблицю Teams.
        // Використовуємо параметри запиту (@name, @country...) а не підстановку рядків напряму —
        // це захищає від SQL-ін'єкції (атака, коли зловмисник вводить SQL-код у поле вводу).
        private static void InsertTeam(SQLiteConnection conn, string name, string country,
                                       int founded, int champ, string logo)
        {
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                "INSERT INTO Teams (team_name, team_country, team_founded, team_championships, team_logo_file) " +
                "VALUES (@name, @country, @founded, @champ, @logo);";
            cmd.Parameters.AddWithValue("@name",    name);
            cmd.Parameters.AddWithValue("@country", country);
            cmd.Parameters.AddWithValue("@founded", founded);
            cmd.Parameters.AddWithValue("@champ",   champ);
            cmd.Parameters.AddWithValue("@logo",    logo);
            // ExecuteNonQuery — для команд INSERT/UPDATE/DELETE (не повертає рядків таблиці)
            cmd.ExecuteNonQuery();
        }

        // Допоміжний метод: вставляє один запис у таблицю Drivers.
        private static void InsertDriver(SQLiteConnection conn, int teamId, string name,
                                         int number, string nat, int wins, double pts, string photo)
        {
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                "INSERT INTO Drivers (team_id, driver_name, driver_number, driver_nationality, " +
                "                     driver_wins, driver_points, driver_photo_file) " +
                "VALUES (@tid, @name, @num, @nat, @wins, @pts, @photo);";
            cmd.Parameters.AddWithValue("@tid",   teamId);
            cmd.Parameters.AddWithValue("@name",  name);
            cmd.Parameters.AddWithValue("@num",   number);
            cmd.Parameters.AddWithValue("@nat",   nat);
            cmd.Parameters.AddWithValue("@wins",  wins);
            cmd.Parameters.AddWithValue("@pts",   pts);
            cmd.Parameters.AddWithValue("@photo", photo);
            cmd.ExecuteNonQuery();
        }

        // ─── CRUD: Teams ──────────────────────────────────────────────────────

        // Перевантаження (overloading) — два методи з однаковою назвою але різними параметрами.
        // Цей варіант без параметрів повертає всі команди, відсортовані за назвою.
        public static DataTable GetTeams()
        {
            return GetTeams("team_name", true, "", "");
        }

        // Повертає команди з сортуванням та фільтрацією.
        // DataTable — таблиця даних у пам'яті (як аркуш Excel з рядками і колонками).
        public static DataTable GetTeams(string sortField, bool ascending,
                                         string filterCountry, string filterChampMin)
        {
            // Визначаємо напрям сортування
            string order;
            if (ascending)
                order = "ASC";   // зростання (A → Z, 0 → 9)
            else
                order = "DESC";  // спадання  (Z → A, 9 → 0)

            // BuildTeamsFilter будує частину WHERE якщо є активні фільтри,
            // або повертає "", якщо фільтрів немає.
            string where = BuildTeamsFilter(filterCountry, filterChampMin);

            string sql = "SELECT team_id, team_name, team_country, team_founded, " +
                         "team_championships, team_logo_file " +
                         "FROM Teams " + where + " ORDER BY " + sortField + " " + order + ";";

            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                // SQLiteDataAdapter — автоматично виконує SQL і заповнює DataTable результатами.
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);  // заповнює таблицю рядками з БД
                    return table;
                }
            }
        }

        // Шукає команди за назвою або країною.
        // LIKE — оператор пошуку підрядка у SQL.
        // "%" означає "будь-яка кількість будь-яких символів".
        // Наприклад: LIKE '%red%' знайде "Red Bull Racing".
        public static DataTable SearchTeams(string searchValue)
        {
            string sql = @"
                SELECT team_id, team_name, team_country, team_founded, team_championships, team_logo_file
                FROM Teams
                WHERE team_name    LIKE @val
                   OR team_country LIKE @val
                ORDER BY team_name ASC;";

            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn))
                {
                    // "%" + searchValue + "%" — шукаємо searchValue будь-де у рядку
                    adapter.SelectCommand.Parameters.AddWithValue("@val", "%" + searchValue + "%");
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        // Додає нову команду до бази даних.
        public static void AddTeam(string name, string country, int founded, int championships, string logoFile)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        "INSERT INTO Teams (team_name, team_country, team_founded, team_championships, team_logo_file) " +
                        "VALUES (@name, @country, @founded, @champ, @logo);";
                    cmd.Parameters.AddWithValue("@name",    name);
                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@founded", founded);
                    cmd.Parameters.AddWithValue("@champ",   championships);
                    cmd.Parameters.AddWithValue("@logo",    logoFile);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Оновлює дані існуючої команди (знаходить за id).
        public static void UpdateTeam(int id, string name, string country, int founded, int championships, string logoFile)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Teams SET
                            team_name=@name, team_country=@country, team_founded=@founded,
                            team_championships=@champ, team_logo_file=@logo
                        WHERE team_id=@id;";
                    cmd.Parameters.AddWithValue("@name",    name);
                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@founded", founded);
                    cmd.Parameters.AddWithValue("@champ",   championships);
                    cmd.Parameters.AddWithValue("@logo",    logoFile);
                    cmd.Parameters.AddWithValue("@id",      id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Видаляє команду та всіх її пілотів (завдяки ON DELETE CASCADE у таблиці Drivers).
        public static void DeleteTeam(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    // Вмикаємо зовнішні ключі перед видаленням, щоб спрацював CASCADE
                    cmd.CommandText = "PRAGMA foreign_keys = ON;";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM Teams WHERE team_id=@id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Повертає один рядок таблиці Teams за id, або null якщо не знайдено.
        // DataRow — один рядок таблиці (доступ до полів: row["team_name"].ToString()).
        public static DataRow GetTeamById(int id)
        {
            string sql = "SELECT * FROM Teams WHERE team_id=@id;";
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@id", id);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Перевіряємо чи знайдено хоч один рядок
                    if (table.Rows.Count > 0)
                        return table.Rows[0];  // повертаємо перший (і єдиний) рядок

                    return null;  // команду не знайдено
                }
            }
        }

        // ─── CRUD: Drivers ────────────────────────────────────────────────────

        // Повертає всіх пілотів вказаної команди.
        // Розраховує поле win_rate (відсоток перемог від всіх очок+перемог).
        public static DataTable GetDriversByTeam(int teamId)
        {
            // Пояснення SQL-формули win_rate:
            // CAST(driver_wins AS REAL) — перетворює ціле в дробове (щоб ділення давало дріб, а не 0)
            // ROUND(..., 2)             — округлює до 2 знаків після коми
            // CASE WHEN ... THEN ... ELSE ... END — умова у SQL (як if-else)
            //   якщо (wins + points) = 0 → повертаємо 0 (щоб не ділити на нуль)
            //   інакше → рахуємо відсоток перемог
            string sql = @"
                SELECT driver_id, team_id, driver_name, driver_number, driver_nationality,
                       driver_wins, driver_points, driver_photo_file,
                       CAST(
                           CASE WHEN (driver_wins + driver_points) = 0 THEN 0
                                ELSE ROUND(CAST(driver_wins AS REAL) / (driver_wins + driver_points) * 100, 2)
                           END AS REAL
                       ) AS win_rate
                FROM Drivers
                WHERE team_id = @tid
                ORDER BY win_rate DESC, driver_wins ASC;";

            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@tid", teamId);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        // Перевантаження без параметрів — повертає всіх пілотів, відсортованих за іменем.
        public static DataTable GetAllDrivers()
        {
            return GetAllDrivers("driver_name", true, "", "");
        }

        // Повертає всіх пілотів (разом з назвою команди) з сортуванням та фільтрацією.
        // JOIN — з'єднання двох таблиць: "d" = Drivers, "t" = Teams.
        // "d.team_id = t.team_id" — умова з'єднання (пілот належить команді з таким самим team_id).
        public static DataTable GetAllDrivers(string sortField, bool ascending,
                                              string filterNat, string filterWinsMin)
        {
            string order;
            if (ascending)
                order = "ASC";
            else
                order = "DESC";

            string where = BuildDriversFilter(filterNat, filterWinsMin);

            string sql =
                "SELECT d.driver_id, d.team_id, t.team_name, d.driver_name, d.driver_number, " +
                "d.driver_nationality, d.driver_wins, d.driver_points, d.driver_photo_file, " +
                "CAST(CASE WHEN (d.driver_wins + d.driver_points) = 0 THEN 0 " +
                "     ELSE ROUND(CAST(d.driver_wins AS REAL) / (d.driver_wins + d.driver_points) * 100, 2) " +
                "     END AS REAL) AS win_rate " +
                "FROM Drivers d JOIN Teams t ON d.team_id = t.team_id " +
                where + " ORDER BY " + sortField + " " + order + ";";

            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        // Шукає пілотів за іменем, національністю або назвою команди.
        public static DataTable SearchDrivers(string searchValue)
        {
            string sql = @"
                SELECT d.driver_id, d.team_id, t.team_name, d.driver_name, d.driver_number,
                       d.driver_nationality, d.driver_wins, d.driver_points, d.driver_photo_file,
                       CAST(
                           CASE WHEN (d.driver_wins + d.driver_points) = 0 THEN 0
                                ELSE ROUND(CAST(d.driver_wins AS REAL) / (d.driver_wins + d.driver_points) * 100, 2)
                           END AS REAL
                       ) AS win_rate
                FROM Drivers d
                JOIN Teams t ON d.team_id = t.team_id
                WHERE d.driver_name        LIKE @val
                   OR d.driver_nationality LIKE @val
                   OR t.team_name          LIKE @val
                ORDER BY d.driver_name ASC;";

            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@val", "%" + searchValue + "%");
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        // Додає нового пілота до бази даних.
        public static void AddDriver(int teamId, string name, int number, string nationality,
                                     int wins, double points, string photoFile)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        "INSERT INTO Drivers (team_id, driver_name, driver_number, driver_nationality, " +
                        "                     driver_wins, driver_points, driver_photo_file) " +
                        "VALUES (@tid, @name, @num, @nat, @wins, @pts, @photo);";
                    cmd.Parameters.AddWithValue("@tid",   teamId);
                    cmd.Parameters.AddWithValue("@name",  name);
                    cmd.Parameters.AddWithValue("@num",   number);
                    cmd.Parameters.AddWithValue("@nat",   nationality);
                    cmd.Parameters.AddWithValue("@wins",  wins);
                    cmd.Parameters.AddWithValue("@pts",   points);
                    cmd.Parameters.AddWithValue("@photo", photoFile);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Оновлює дані пілота (знаходить за id).
        public static void UpdateDriver(int id, int teamId, string name, int number, string nationality,
                                        int wins, double points, string photoFile)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Drivers SET
                            team_id=@tid, driver_name=@name, driver_number=@num,
                            driver_nationality=@nat, driver_wins=@wins, driver_points=@pts,
                            driver_photo_file=@photo
                        WHERE driver_id=@id;";
                    cmd.Parameters.AddWithValue("@tid",   teamId);
                    cmd.Parameters.AddWithValue("@name",  name);
                    cmd.Parameters.AddWithValue("@num",   number);
                    cmd.Parameters.AddWithValue("@nat",   nationality);
                    cmd.Parameters.AddWithValue("@wins",  wins);
                    cmd.Parameters.AddWithValue("@pts",   points);
                    cmd.Parameters.AddWithValue("@photo", photoFile);
                    cmd.Parameters.AddWithValue("@id",    id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Видаляє пілота за його id.
        public static void DeleteDriver(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Drivers WHERE driver_id=@id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Повертає один рядок таблиці Drivers за id.
        public static DataRow GetDriverById(int id)
        {
            string sql = @"
                SELECT d.*, t.team_name,
                       CAST(
                           CASE WHEN (d.driver_wins + d.driver_points) = 0 THEN 0
                                ELSE ROUND(CAST(d.driver_wins AS REAL) / (d.driver_wins + d.driver_points) * 100, 2)
                           END AS REAL
                       ) AS win_rate
                FROM Drivers d
                JOIN Teams t ON d.team_id = t.team_id
                WHERE d.driver_id=@id;";

            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@id", id);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                        return table.Rows[0];

                    return null;
                }
            }
        }

        // ─── Список команд для ComboBox ───────────────────────────────────────

        // Повертає таблицю з двох колонок: team_id і team_name.
        // Використовується у DriverEditForm для заповнення випадаючого списку команд.
        public static DataTable GetTeamsList()
        {
            string sql = "SELECT team_id, team_name FROM Teams ORDER BY team_name ASC;";
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        // ─── Фільтри ─────────────────────────────────────────────────────────

        // Будує частину SQL-запиту "WHERE ..." для фільтрації команд.
        // Якщо фільтри не задані — повертає "" (порожній рядок).
        private static string BuildTeamsFilter(string country, string champMin)
        {
            string where = "";
            int champVal;

            // string.IsNullOrWhiteSpace — true якщо рядок порожній, null, або складається з пробілів
            if (!string.IsNullOrWhiteSpace(country))
            {
                // Replace("'", "''") — екранує одинарні лапки у значенні (захист від SQL-ін'єкції)
                where = "WHERE team_country LIKE '%" + country.Replace("'", "''") + "%'";
            }

            // int.TryParse — намагається перетворити рядок у ціле число.
            // "out champVal" — якщо вдалось, результат записується в champVal.
            // Метод повертає true якщо перетворення успішне, false якщо рядок не є числом.
            if (!string.IsNullOrWhiteSpace(champMin) && int.TryParse(champMin, out champVal))
            {
                if (where == "")
                    where = "WHERE team_championships >= " + champVal;
                else
                    where = where + " AND team_championships >= " + champVal;
            }

            return where;
        }

        // Будує частину SQL-запиту "WHERE ..." для фільтрації пілотів.
        private static string BuildDriversFilter(string nationality, string winsMin)
        {
            string where = "";
            int winsVal;

            if (!string.IsNullOrWhiteSpace(nationality))
            {
                where = "WHERE d.driver_nationality LIKE '%" + nationality.Replace("'", "''") + "%'";
            }

            if (!string.IsNullOrWhiteSpace(winsMin) && int.TryParse(winsMin, out winsVal))
            {
                if (where == "")
                    where = "WHERE d.driver_wins >= " + winsVal;
                else
                    where = where + " AND d.driver_wins >= " + winsVal;
            }

            return where;
        }
    }
}
