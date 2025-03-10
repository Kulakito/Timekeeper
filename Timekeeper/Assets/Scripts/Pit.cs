public class Pit : Trigger
{
    public override void TriggerObject(bool active)
    {
        gameObject.SetActive(!active);
    }
}
