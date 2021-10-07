// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.14.0

// Modified by Teju Peri - *** 10-6-21 ***  Arlington County - MS Solution Architect Role

using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ACG_DPR_CodeTest_Bot.Bots
{
    public class EchoBot : ActivityHandler
    {
        private const string welcomeText = "This is a modified Welcome Bot sample by Teju. You will be introduced by the bot now ";
        private const string localeText = "welcome the user using their Locale ";
        private const string infoText = "Seems like you joined the conversation!";      



        /*For simplicity sake I am just changing per the requirement. 
         Please see my solution/readme for a more extensive solution/extension for this*/

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            //Convert to Lowercase
            var inputText = turnContext.Activity.Text.ToLowerInvariant();


            /* The following logic can be developed in a more dynamic way using 
             language understanding like QnA, LUIS etc. */


            switch (inputText)
            {

                case "how are you":
                    {
                        string responseToHowru = "I'm great!";
                        await turnContext.SendActivityAsync(MessageFactory.Text(responseToHowru, responseToHowru), cancellationToken: cancellationToken);
                    }
                    break;

                case "hello":
                    {
                        string responseToHello = "Hello there!";
                        await turnContext.SendActivityAsync(MessageFactory.Text(responseToHello, responseToHello), cancellationToken);
                    }
                    break;
                default:
                    {
                        string responseEcho = $"Echo: {turnContext.Activity.Text}";
                        await turnContext.SendActivityAsync(MessageFactory.Text(responseEcho, responseEcho), cancellationToken);
                       
                    }
                    break;

            }

               
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync($"Hello Bot User - {member.Name}. {welcomeText}", cancellationToken: cancellationToken);
                    await turnContext.SendActivityAsync($"{localeText} Dear Bot User your locale is '{turnContext.Activity.GetLocale()}'.", cancellationToken: cancellationToken);
                    await turnContext.SendActivityAsync(infoText, cancellationToken: cancellationToken);
                 
                }
            }
        }
    }
}
