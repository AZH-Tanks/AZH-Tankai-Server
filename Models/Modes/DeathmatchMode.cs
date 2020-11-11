namespace AZH_Tankai_Server.Models
{
    public class DeathmatchMode : Mode
    {
        public short RoundDuration { get; set; }
        public override string InitiateMode()
        {
            return "ReceiveRoomDeathmatch";
        }
    }
}
