using AzureFunctions.Autofac;
using Quiplogs.Notifications.Process;
using Quiplogs.Notifications.Process.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace EmailFunction
{
    [DependencyInjectionConfig(typeof(ProcessNotificationModule))]
    public static class EmailQueueFunction
    {
        [FunctionName("EmailQueueFunction")]
        public static void Run([QueueTrigger("qu-email-send", Connection = "AzureWebJobsStorage")] byte[] encryptedMail, [Inject] ISendGridService sendGridService, ILogger log)
        {
            sendGridService.SendMail(encryptedMail);
            log.LogInformation($"Emailed sent");
        }
    }
}
