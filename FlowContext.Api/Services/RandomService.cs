using FlowContext.Api.Helpers;

namespace FlowContext.Api.Services
{
    public interface IRandomService
    {
        public Task DoAction();
    }
    public class RandomService : IRandomService
    {
        private readonly ICustomLogger _customLogger;

        public RandomService(ICustomLogger customLogger)
        {
            _customLogger = customLogger;
        }

        public async Task DoAction()
        {
            _customLogger.Log("a test service");
            await Task.Delay(1);
        }
    }
}
