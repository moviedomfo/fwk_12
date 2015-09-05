<%@ Page Title="" Language="C#" MasterPageFile="~/Site2c.Master" AutoEventWireup="true"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentCenter" runat="server">
 <style>
  .frm_text_type_1
  {
  	color: #666666; font-weight: bold; font-family: Arial, Helvetica, sans-serif";
  	}
 </style>
    <div class="article_wrap" style="margin: 40px; width: 660px">
        <div class="frm_title frm_title_3" style="margin-top: 30px; width: 700px">
            Enviropment mannager & service dispatchers
        </div>
         <span>
                    <img class="img_src" src="/img/webaccess.jpg" alt="" style="float: left; height: 69px;
                        width: 174px; margin-right: 10px" />
                </span>
        <div>
            <p class="frm_text_type_1">
                From this panel you have access to all service mamnager registered.
                To make diferents activities avobe listed you mas have the access permision.
              
                For more information about, please contact with the site admin.
               
                Also, you can do a quick read of your permissions consulting on MyProfile
                
            </p>
            <div class="clear">
            </div>
        </div>
        <br />
        <div>
            <div>
                <span>
                    <img class="img_src" src="/img/new-disp.jpg" alt="" style="float: left; height: 69px;
                        width: 174px; margin-right: 10px" />
                </span>
                <a class="frm_title frm_sub_title_2"  href="disp_new.aspx" style="text-decoration: none">
                    Register new environment/dispatcher
                </a>
                <p>
                This action allows you create new environment for a dispatcher web or remoting
                </p>
                <p>It is recommended that the dispatcher service is installed and running,
                so you can sincronizarce its metadata and configuration with the environment you are registering.
                </p>
            </div>
            <div>
                <span>
                    <img class="img_src" src="/img/login.jpg" alt="" style="float: left; height: 69px;
                        width: 174px; margin-right: 10px" />
                </span>
                <p class="frm_title frm_sub_title_2" style="text-decoration: none">
                   <a  class="frm_title frm_sub_title_2" href="disp_singin.aspx"> Login to existent environment </a> 
                </p>
                <p>
                    Click this option to manage diferents settings for previously environment registered  
                </p>
            </div>
            
        </div>
    </div>

      <div class="article_wrap" style="margin: 10px; width: 660px;color: #666666; font-weight: bold; font-family: Arial, Helvetica, sans-serif">
          
      </div>
</asp:Content>
