public enum Status {
    TODO = 0,
    IN_PROGRESS = 1,
    DONE = 2
}
internal class Task {
    public int id { get; set; }
    public string item { get; set; }
    public Status status { get; set; }
}