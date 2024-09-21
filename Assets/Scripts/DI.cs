
public class DI
{
    public static DI di = new DI();

    public InputManager input { get; private set; } = new InputManager();
    public Savemanager savemanager { get; private set; }
    public Economymanager economymanager = new Economymanager();
    public QueueManager queueManager { get; private set; }

    public void SetSaveManager(Savemanager savemanager) => this.savemanager = savemanager;
    public void SetQueueManager(QueueManager queueManager) => this.queueManager = queueManager;


    private DI() { }
}