using GksKatowiceBot.Helpers;
using Microsoft.Bot.Connector;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GksKatowiceBot.Controllers
{
    public class ThreadClass
    {
        public async static void SendThreadMessage(DataRow dr)
        {
            try
            {
                  //  BaseDB.AddToLog("Wywołanie metody SendThreadMessage");

                    List<IGrouping<string, string>> hrefList = new List<IGrouping<string, string>>();
                    List<IGrouping<string, string>> hrefList2 = new List<IGrouping<string, string>>();
                    List<IGrouping<string, string>> hreflist3 = new List<IGrouping<string, string>>();
                    List<IGrouping<string, string>> hreflist4 = new List<IGrouping<string, string>>();
                    var items = BaseGETMethod.GetCardsAttachmentsNowosci(ref hrefList);
                    hreflist3 = hrefList;
                    var items2 = BaseGETMethod.GetCardsAttachmentsWydarzenia(ref hrefList2);
                    var items4 = BaseGETMethod.GetCardsAttachmentsPromocje(ref hreflist4);

                    var items3 = new List<Attachment>();

                    if (items.Count > 0)
                    {
                        foreach(var item in items)
                        {
                            items3.Add(item);
                        }
                    }
                    if(items4.Count>0 && items3.Count<=5)
                    {
                        foreach (var item in items4)
                        {
                            if (items3.Count < 10)
                            {
                                items3.Add(item);
                            }
                        }
                    }

                    items = items3;


                    string uzytkownik = "";

                    if (items.Count > 0)
                    {
                        try
                        {
                            MicrosoftAppCredentials.TrustServiceUrl(@"https://facebook.botframework.com", DateTime.MaxValue);

                            IMessageActivity message = Activity.CreateMessageActivity();
                            message.ChannelData = JObject.FromObject(new
                            {
                                notification_type = "REGULAR",
                                quick_replies = new dynamic[]
                                    {
                                                                                             new
                                {
                                    content_type = "text",
                                    title = "Nowości",
                                    payload = "DEVELOPER_DEFINED_PAYLOAD_Nowosci",
                                    //     image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Green%20Ball.png"
                                 //   image_url = "http://archiwum.koluszki.pl/zdjecia/naglowki_nowe/listopad%202013/pi%C5%82ka[1].png"
                                },
                                new
                                {
                                    content_type = "text",
                                    title = "Wydarzenia",
                                    payload = "DEVELOPER_DEFINED_PAYLOAD_Wydarzenia",
                               //       image_url = "https://gim7bytom.edupage.org/global/pics/iconspro/sport/volleyball.png"
                                },
                                new
                                {
                                    content_type = "text",
                                    title = "Promocje",
                                    payload = "DEVELOPER_DEFINED_PAYLOAD_Promocje",
                                //       image_url = "https://www.samo-lepky.sk/data/11/hokej5.png"
                                },
                                                                   }
                            });

                            message.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                            message.Attachments = items;

                                try
                                {
                                    var userAccount = new ChannelAccount(name: dr["UserName"].ToString(), id: dr["UserId"].ToString());
                                    uzytkownik = userAccount.Name;
                                    var botAccount = new ChannelAccount(name: dr["BotName"].ToString(), id: dr["BotId"].ToString());
                                    var connector = new ConnectorClient(new Uri(dr["Url"].ToString()), "18314f1a-401b-4a7c-a775-411103a7435a", "Xsjq8xvidojn5xNctr4FuLB");
                                    var conversationId = await connector.Conversations.CreateDirectConversationAsync(botAccount, userAccount);
                                    message.From = botAccount;
                                    message.Recipient = userAccount;
                                    message.Conversation = new ConversationAccount(id: conversationId.Id, isGroup: false);
                                    await connector.Conversations.SendToConversationAsync((Activity)message).ConfigureAwait(false);
                                }
                                catch (Exception ex)
                                {
                                    BaseDB.AddToLog("Błąd wysyłania wiadomości do: " + uzytkownik + " " + ex.ToString());
                                }

                        }
                        catch (Exception ex)
                        {
                            BaseDB.AddToLog("Błąd wysyłania wiadomości do: " + uzytkownik + " " + ex.ToString());
                        }


                        BaseDB.AddWiadomosci(hrefList);

                        BaseDB.AddWiadomosciWydarzenia(hrefList2);
                        BaseDB.AddWiadomosciPromocje(hreflist4);
                    }
                
            }
            catch (Exception ex)
            {
                BaseDB.AddToLog("Błąd wysłania wiadomosci: " + ex.ToString());
            }
        }
    }
}