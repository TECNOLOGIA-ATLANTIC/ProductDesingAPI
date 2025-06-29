namespace AtlanticProductDesing.Application.Enums
{
    public class ProjectStatus
    {
        public static ProjectStatus Created { get; } = new ProjectStatus(1, "Creado");
        public static ProjectStatus Opened { get; } = new ProjectStatus(2, "Abierto");
        public static ProjectStatus Deleted { get; } = new ProjectStatus(3, "Eliminado");
        public static ProjectStatus ForClosed { get; } = new ProjectStatus(4, "Por Cerrar");
        public static ProjectStatus Closed { get; } = new ProjectStatus(5, "Cerrado");

        public string Name { get; private set; }
        public int Value { get; private set; }

        private ProjectStatus(int val, string name)
        {
            Value = val;
            Name = name;
        }

        public static IEnumerable<ProjectStatus> List()
        {
            return new[] { Created, Opened, Deleted, ForClosed, Closed };
        }

        public static ProjectStatus FromString(string name) => List().SingleOrDefault(r => String.Equals(r.Name, name, StringComparison.OrdinalIgnoreCase));

        public static ProjectStatus FromValue(int value) => List().SingleOrDefault(r => r.Value == value);
    }
}
