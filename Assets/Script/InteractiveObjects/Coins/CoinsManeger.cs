public class CoinsManeger
{
    private int Coins;

    public void AddCoin(int coinsToAdd)
    {
        Coins += coinsToAdd;
    }

    public int GetCoin()
    {
        return Coins;
    }
}