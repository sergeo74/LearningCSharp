using System.ServiceModel;

namespace MagicEightBallServiceLib
{
    [ServiceContract]
    public interface IEightBall
    {
        // Задайте вопрос, получите ответ!
        [OperationContract]
        string ObtainAnswerToQuestion(string userQuestion);
    }
}