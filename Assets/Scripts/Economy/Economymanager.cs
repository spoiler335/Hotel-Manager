using UnityEngine;

public class Economymanager
{
    public EconomyModel model { get; private set; } = new EconomyModel();

    public Economymanager()
    {
        EventsModel.SAVE_DATA_READY -= Initialize;
        EventsModel.SAVE_DATA_READY += Initialize;
    }

    private void Initialize()
    {
        if (DI.di.savemanager == null) return;
        model = DI.di.savemanager.model.economy;
    }

    public void AddCoins(int amount)
    {
        model.coins += amount;
        if (model.coins < 0) model.coins = 0;
    }
}