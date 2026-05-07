public static class GameData
{
    public static int playerAIndex = 0;
    public static int playerBIndex = 0;

    public static int currentPlayer = 0;
    public static bool bombGameFinished = false;
    public static bool bombExploded = false; // 爆弾が爆発したかどうか
    public static int bombExplodedPlayer = -1; // 爆発したプレイヤー（0=A, 1=B）
}
