
/// <summary>
/// 状態異常
/// </summary>
public enum AbnormalState
{
    毒 = 0b1000, 火傷 = 0b0100, 眠り = 0b0010, 麻痺 = 0b0001
}

/// <summary>
/// モンスター系統
/// </summary>
public enum LineageID
{
    むし, スライム, おに, けもの,
    とり, あくま, さかな
}
public enum むし
{
    が, げじげじ, かまきり,
}
public enum スライム
{
    スライム,
}
public enum おに
{
    ゴブリン,
}
public enum けもの
{
    ねこ,
}
public enum とり
{
    からす,
}
public enum あくま
{
    レッサーデーモン,
}
public enum さかな
{
    サーモン,
}
