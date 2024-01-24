<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmailApprove.aspx.cs" Inherits="EmailApprove" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Welcome Email Approver page</title>
    <style type="text/css">
        
        body {
              background-color: beige;
              margin: 0;
              padding: 0;
              font-family: Arial, Helvetica, sans-serif;
            }
        h1 {
            color : #000000;
            text-align : center;
            font-family: "SIMPSON";
           }
        /* Add padding to containers */
         /*.container {
                      padding: 16px;
                      background-color: white;
                   }*/
         
           * {
               box-sizing: border-box;
             }
     form {
            width: 300px;
            margin: 0 auto;
          }
     td {
         font-weight: bold;
        }
     .btn {
            background-color: dodgerblue;
            color: white;
            padding: 15px 20px;
            border: none;
           cursor: pointer;
           width: 100%;
          opacity: 0.9;
      }
     .image {
              display: block;
              width: 30%;
              height: auto;
            }

           
    </style>
</head>
<body>  
    <form id="form1" runat="server">  
        <div class="container">
            <img src="Help/en/OLT_icon_48.gif" alt="Avatar" class="image"/>
           
         </div>

        <div class="container"> 
            <h1>CSD Approval Form</h1> 
             <p style="width: 450px"><strong>Please select Approve/Reject and click Submit button</strong></p>
            <table class="auto-style1">  
                <tr style="display:none">  
                    <td>CSD FormId:</td>  
                    <td>  
                        <asp:TextBox ID="csdFormID" runat="server" Width="164px"></asp:TextBox>  
                        <br />
                    </td>  
  
               </tr> 
                 <tr>  
                    
                    <td>
                        <asp:Label id="lblStartDate" Text="CSD Start Date:" runat="server"></asp:Label>
                    </td>
                    <td>  
                        <asp:TextBox ID="txtStartDate" runat="server" Width="219px" Height="19px" Enabled="false"></asp:TextBox>  
                        <br />
                    </td>  
  
               </tr> 
                <tr>
                    
                </tr>
                <tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr>

                <tr>  
                    <td>CSD End Date:</td>  
                     <td> <asp:TextBox ID="formStatusId" runat="server" Width="221px" Enabled="false"></asp:TextBox></td>  
                </tr>  
                
                <tr>
                    
                </tr>
                <tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr>
                <tr>  
                    
                    <td>
                        <asp:Label id="lblCsddefeat" Text="Critical System Defeated:" runat="server"></asp:Label>
                    </td>
                    <td>  
                        <asp:Textbox TextMode="MultiLine" ID="criticalSystemDefeated" runat="server" Width="400px" Height="60px" Enabled="false"></asp:Textbox>  
                    </td>  
                </tr>  
                 <tr>
                    
                </tr>
                <tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr>
                 <tr style="display:none">  
                    <td>Last Modified ByUser Id:</td>  
                    <td>  
                        <asp:TextBox ID="lastModifiedByUserId" runat="server" Width="154px"></asp:TextBox>  
                    </td>  
                </tr>
                <tr style="display:none">  
                    <td>Site Id:</td>  
                    <td>  
                        <asp:TextBox ID="siteid" runat="server" Width="152px"></asp:TextBox>  
                    </td>  
                </tr>
                 <tr style="display:none">  
                    <td>Approve Id:</td>  
                    <td>  
                        <asp:TextBox ID="approveId" runat="server" Width="150px"></asp:TextBox>  
                    </td>  
                </tr>
                <tr>  
                    <td>
                         <asp:Label id="lblRole" Text="Role Approval for:" runat="server"></asp:Label>
                    </td> 
                     
                    <td>  
                        <asp:TextBox ID="txtRole" runat="server" Width="221px" Enabled="false"></asp:TextBox>  
                    </td>  
                </tr>
                <tr>
                    
                </tr>
                <tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr>
                 <tr style="display:none">  
                    <td>Approver User Id:</td>  
                    <td>  
                        <asp:TextBox ID="approvedByUserId" runat="server" Height="22px" Width="150px"></asp:TextBox>  
                    </td>  
                </tr>
                 <tr style="display:none">  
                    <td>Should Be Enabled BehaviourId:</td>  
                    <td>  
                        <asp:TextBox ID="shouldBeEnabledBehaviourId" runat="server" Height="27px" Width="146px"></asp:TextBox>  
                    </td>  
                </tr>
                <tr style="display:none">  
                    <td>Enabled:</td>  
                    <td>  
                        <asp:TextBox ID="enabled" runat="server" Width="151px"></asp:TextBox>  
                    </td>  
                </tr>
               <tr>
                        <td class="auto-style1">Comments:</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtComment" runat="server" Height="60px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                        </td>
                   <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtComment" ErrorMessage="Please Provide Comment" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
                        </td>
              </tr>
                <tr>
                    
                </tr>
                <tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr>
                        
                <tr>  
                    <td>Approve/Reject:</td>  
                    <td>  
                        <asp:DropDownList ID="DropDownList1" runat="server">  
                            <asp:ListItem  Selected="True">--Select--</asp:ListItem>  
                            <asp:ListItem Text="Approve" Value="Approve"></asp:ListItem>  
                            <asp:ListItem Text="Reject" Value="Reject"></asp:ListItem>  
                        </asp:DropDownList>  
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1"
                ErrorMessage="Select Approve/Reject before submit" InitialValue="--Select--" ForeColor="Red"></asp:RequiredFieldValidator>
                       
                    </td>  
                </tr>  
                <tr>
                    
                </tr>
                <tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr>
                    
                </tr>
                <tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr>
                    
                </tr>
                <tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr>
                <tr>  
                    <td></td>
                    
                    <td>  
                        <asp:Button class="btn" ID="btnSubmit" width="100px"   runat="server" Text="Submit"  OnClick="btnSubmit_Click" />  
                    </td>  
                </tr>  
            </table>  
        </div>  
    </form>  
</body>  
</html>
