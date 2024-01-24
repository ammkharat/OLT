using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
namespace Com.Suncor.Olt.Client.Presenters
{
    class ShiftLogMessagesPresenter
    {
        IShiftHandoverService service;

        public  ShiftLogMessagesPresenter()
        {
            service = ClientServiceRegistry.Instance.GetService<IShiftHandoverService>();
        }
             
        public List<ShiftLogMessage> Getdata()
        {

            return service.QueryShiftLogMessage(Client.ClientSession.GetUserContext().RootFlocSet,0);

        }
        private string InsertTableInRichtextbox()
        {
            //CreateStringBuilder object
            StringBuilder strTable = new StringBuilder();

            //Beginning of rich text format,don’t alter this line
            strTable.Append(@"{\rtf1 ");

            //Create 5 rows with 4 columns
            for (int i = 0; i < 5; i++)
            {
                //Start the row
                strTable.Append(@"\trowd");

                //First cell with width 1000.
                strTable.Append(@"\cellx1000");

                //Second cell with width 1000.Ending point is 2000, which is 1000+1000.
                strTable.Append(@"\cellx2000");

                //Third cell with width 1000.Endingat3000,which is 2000+1000.
                strTable.Append(@"\cellx3000");

                //Last cell with width 1000.Ending at 4000 (which is 3000+1000)
                strTable.Append(@"\cellx4000");

                //Append the row in StringBuilder
                strTable.Append(@"\intbl \cell \row"); //create the row
            }

            strTable.Append(@"\pard");

            strTable.Append(@"}");

            return strTable.ToString();
        }
        private static String InsertTableInRichTextBox(int rows, int cols, int width)
        {
            //Create StringBuilder Instance
            StringBuilder sringTableRtf = new StringBuilder();

            //beginning of rich text format
            sringTableRtf.Append(@"{\rtf1 ");

            //Variable for cell width
            int cellWidth;

            //Start row
            sringTableRtf.Append(@"\trowd");

            //Loop to create table string
            for (int i = 0; i< rows; i++)
            {
               sringTableRtf.Append(@"\trowd");

               for (int j = 0; j < cols; j++)
               {
                   //Calculate cell end point for each cell
                   cellWidth = (j + 1) * width;

                   //A cell with width 1000 in each iteration.
                  sringTableRtf.Append(@"\cellx" + cellWidth.ToString());
               }

               //Append the row in StringBuilder
               sringTableRtf.Append(@"\intbl \cell \row");
            }
            sringTableRtf.Append(@"\pard");
            sringTableRtf.Append(@"}");

            return sringTableRtf.ToString();
         }
        public String GetTableRTF(List<ShiftLogMessage> lst)
        {
                    
            StringBuilder tableRtf = new StringBuilder();

            tableRtf.Append(@"{\rtf1\fbidis\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Arial;}}");
           
           //tableRtf.Append(@"{\rtf1");

           tableRtf.Append(@"\trowd\trgaph300");
           tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx10200" + @"\b \fs20 Operator Round Messages from Meridium \fs20 \b0 " + @"\intbl\clmrg\cell\row");
          

           //Table Logic started

            tableRtf.Append(@"\trowd\trgaph300");
            tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx2000" + "  " + @"\b\fs20 User Name \fs20 \b0 ");
            tableRtf.Append(@"\intbl\cell");

            tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx4500" + " " + @"\b Functional Location \b0 ");
            tableRtf.Append(@"\intbl\cell");

            //tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx5000" + " " + @"\b Source \b0 ");
           // tableRtf.Append(@"\intbl\cell");

            tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx10200");
            tableRtf.Append("   " + @"\b Message \b0 " + @"\intbl\clmrg\cell\row");

            int j = 0;
            foreach(ShiftLogMessage Message in lst)
            {
              
                tableRtf.Append(@"\trowd");
                tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx2000" + "  " + Message.UserName);
                tableRtf.Append(@"\intbl\cell");

                tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx4500" + " " + Message.Floc);
                tableRtf.Append(@"\intbl\cell");

               // tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx5000" + " " + Message.Source);
                //tableRtf.Append(@"\intbl\cell");

                tableRtf.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\clwWidth2000\cellx10200");
                tableRtf.Append("   " + Message.Message + @"\intbl\clmrg\cell\row");


            }


            tableRtf.Append(@"\pard");
            tableRtf.Append(@"}");
           
         return tableRtf.ToString();
          
        }



        //Function to Create a shift log for Operator Round

        public void CreateLogforRound(List<FunctionalLocation> FN, string logMessage)
        {
            UserContext userContext = ClientSession.GetUserContext();
            Log logOnly = new Log(null,
                                     null,
                                     null,
                                     DataSource.OPERATOR_ROUND,
                                     FN,
                                     false, false, false, false, false, false,
                                     logMessage,
                                     "",
                                     DateTime.Now,
                                     userContext.UserShift.ShiftPattern,
                                     userContext.User,
                                     userContext.User,
                                       DateTime.Now,
                                       DateTime.Now,
                                     false,
                                     false,
                                     userContext.Role,
                                     LogType.Standard,
                                     userContext.Assignment);
            ClientServiceRegistry clientServiceRegistry = ClientServiceRegistry.Instance;
            ILogService logService =  clientServiceRegistry.GetService<ILogService>();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.LogCreate, logService.Insert, logOnly);
        }

        private Log CreateDefaultLog(DateTime now,List<FunctionalLocation> FN)
        {
          UserContext  userContext = ClientSession.GetUserContext();
            return new Log(null,
                           null,
                           null,
                           DataSource.MANUAL,
                           FN,
                           //GetDefaultFlocs(),
                           false,
                           false,
                           false,
                           false,
                           false,
                           false,
                           null,
                           null,
                           now,
                           userContext.UserShift.ShiftPattern,
                           userContext.User,
                           userContext.User,
                           now,
                           now,
                           false,
                           false,
                           userContext.Role,
                           new List<DocumentLink>(),
                           LogType.Standard,
                           false,
                           userContext.Assignment,
                           new List<CustomFieldEntry>(),
                           new List<CustomField>());
        }
    }
}
