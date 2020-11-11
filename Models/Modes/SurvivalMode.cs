namespace AZH_Tankai_Server.Models
{
    public class SurvivalMode : Mode
    {

        public override string InitiateMode()
        {
            return "ReceiveRoomSurvival";
        }
    }
}
