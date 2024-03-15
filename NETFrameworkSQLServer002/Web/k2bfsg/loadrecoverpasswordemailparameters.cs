using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.k2bfsg {
   public class loadrecoverpasswordemailparameters : GXProcedure
   {
      public loadrecoverpasswordemailparameters( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public loadrecoverpasswordemailparameters( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out bool aP0_SendPasswordEmail ,
                           out string aP1_MailSubject ,
                           out string aP2_MailMessage ,
                           out string aP3_SMTPServerName ,
                           out string aP4_SMTPUserName ,
                           out string aP5_SMTPPassword ,
                           out short aP6_SMTPPort ,
                           out short aP7_SMTPAuthentication ,
                           out string aP8_SMTPSenderName ,
                           out string aP9_SMTPSenderAddress ,
                           out short aP10_MinMinutesBetweenEmails ,
                           out string aP11_ServerHost ,
                           out int aP12_ServerPort ,
                           out string aP13_ServerBaseURL )
      {
         this.AV13SendPasswordEmail = false ;
         this.AV11MailSubject = "" ;
         this.AV10MailMessage = "" ;
         this.AV22SMTPServerName = "" ;
         this.AV23SMTPUserName = "" ;
         this.AV18SMTPPassword = "" ;
         this.AV19SMTPPort = 0 ;
         this.AV17SMTPAuthentication = 0 ;
         this.AV21SMTPSenderName = "" ;
         this.AV20SMTPSenderAddress = "" ;
         this.AV12MinMinutesBetweenEmails = 0 ;
         this.AV15ServerHost = "" ;
         this.AV16ServerPort = 0 ;
         this.AV14ServerBaseURL = "" ;
         initialize();
         executePrivate();
         aP0_SendPasswordEmail=this.AV13SendPasswordEmail;
         aP1_MailSubject=this.AV11MailSubject;
         aP2_MailMessage=this.AV10MailMessage;
         aP3_SMTPServerName=this.AV22SMTPServerName;
         aP4_SMTPUserName=this.AV23SMTPUserName;
         aP5_SMTPPassword=this.AV18SMTPPassword;
         aP6_SMTPPort=this.AV19SMTPPort;
         aP7_SMTPAuthentication=this.AV17SMTPAuthentication;
         aP8_SMTPSenderName=this.AV21SMTPSenderName;
         aP9_SMTPSenderAddress=this.AV20SMTPSenderAddress;
         aP10_MinMinutesBetweenEmails=this.AV12MinMinutesBetweenEmails;
         aP11_ServerHost=this.AV15ServerHost;
         aP12_ServerPort=this.AV16ServerPort;
         aP13_ServerBaseURL=this.AV14ServerBaseURL;
      }

      public string executeUdp( out bool aP0_SendPasswordEmail ,
                                out string aP1_MailSubject ,
                                out string aP2_MailMessage ,
                                out string aP3_SMTPServerName ,
                                out string aP4_SMTPUserName ,
                                out string aP5_SMTPPassword ,
                                out short aP6_SMTPPort ,
                                out short aP7_SMTPAuthentication ,
                                out string aP8_SMTPSenderName ,
                                out string aP9_SMTPSenderAddress ,
                                out short aP10_MinMinutesBetweenEmails ,
                                out string aP11_ServerHost ,
                                out int aP12_ServerPort )
      {
         execute(out aP0_SendPasswordEmail, out aP1_MailSubject, out aP2_MailMessage, out aP3_SMTPServerName, out aP4_SMTPUserName, out aP5_SMTPPassword, out aP6_SMTPPort, out aP7_SMTPAuthentication, out aP8_SMTPSenderName, out aP9_SMTPSenderAddress, out aP10_MinMinutesBetweenEmails, out aP11_ServerHost, out aP12_ServerPort, out aP13_ServerBaseURL);
         return AV14ServerBaseURL ;
      }

      public void executeSubmit( out bool aP0_SendPasswordEmail ,
                                 out string aP1_MailSubject ,
                                 out string aP2_MailMessage ,
                                 out string aP3_SMTPServerName ,
                                 out string aP4_SMTPUserName ,
                                 out string aP5_SMTPPassword ,
                                 out short aP6_SMTPPort ,
                                 out short aP7_SMTPAuthentication ,
                                 out string aP8_SMTPSenderName ,
                                 out string aP9_SMTPSenderAddress ,
                                 out short aP10_MinMinutesBetweenEmails ,
                                 out string aP11_ServerHost ,
                                 out int aP12_ServerPort ,
                                 out string aP13_ServerBaseURL )
      {
         loadrecoverpasswordemailparameters objloadrecoverpasswordemailparameters;
         objloadrecoverpasswordemailparameters = new loadrecoverpasswordemailparameters();
         objloadrecoverpasswordemailparameters.AV13SendPasswordEmail = false ;
         objloadrecoverpasswordemailparameters.AV11MailSubject = "" ;
         objloadrecoverpasswordemailparameters.AV10MailMessage = "" ;
         objloadrecoverpasswordemailparameters.AV22SMTPServerName = "" ;
         objloadrecoverpasswordemailparameters.AV23SMTPUserName = "" ;
         objloadrecoverpasswordemailparameters.AV18SMTPPassword = "" ;
         objloadrecoverpasswordemailparameters.AV19SMTPPort = 0 ;
         objloadrecoverpasswordemailparameters.AV17SMTPAuthentication = 0 ;
         objloadrecoverpasswordemailparameters.AV21SMTPSenderName = "" ;
         objloadrecoverpasswordemailparameters.AV20SMTPSenderAddress = "" ;
         objloadrecoverpasswordemailparameters.AV12MinMinutesBetweenEmails = 0 ;
         objloadrecoverpasswordemailparameters.AV15ServerHost = "" ;
         objloadrecoverpasswordemailparameters.AV16ServerPort = 0 ;
         objloadrecoverpasswordemailparameters.AV14ServerBaseURL = "" ;
         objloadrecoverpasswordemailparameters.context.SetSubmitInitialConfig(context);
         objloadrecoverpasswordemailparameters.initialize();
         Submit( executePrivateCatch,objloadrecoverpasswordemailparameters);
         aP0_SendPasswordEmail=this.AV13SendPasswordEmail;
         aP1_MailSubject=this.AV11MailSubject;
         aP2_MailMessage=this.AV10MailMessage;
         aP3_SMTPServerName=this.AV22SMTPServerName;
         aP4_SMTPUserName=this.AV23SMTPUserName;
         aP5_SMTPPassword=this.AV18SMTPPassword;
         aP6_SMTPPort=this.AV19SMTPPort;
         aP7_SMTPAuthentication=this.AV17SMTPAuthentication;
         aP8_SMTPSenderName=this.AV21SMTPSenderName;
         aP9_SMTPSenderAddress=this.AV20SMTPSenderAddress;
         aP10_MinMinutesBetweenEmails=this.AV12MinMinutesBetweenEmails;
         aP11_ServerHost=this.AV15ServerHost;
         aP12_ServerPort=this.AV16ServerPort;
         aP13_ServerBaseURL=this.AV14ServerBaseURL;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadrecoverpasswordemailparameters)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13SendPasswordEmail = true;
         AV11MailSubject = "Password Recovery";
         AV10MailMessage = "Hello %2 %3,<p>" + "You can reset your password <a href='%1'>here</a><p>" + "If this message was not sent by you, you can ignore it.<p>" + "If this happens frequently, please contact your administrator.<p>" + "Regards,";
         AV22SMTPServerName = "";
         AV23SMTPUserName = "";
         AV18SMTPPassword = "";
         AV19SMTPPort = 25;
         AV17SMTPAuthentication = 1;
         AV21SMTPSenderName = "";
         AV20SMTPSenderAddress = "";
         AV12MinMinutesBetweenEmails = 15;
         AV15ServerHost = "";
         AV16ServerPort = 8080;
         AV14ServerBaseURL = "";
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV11MailSubject = "";
         AV10MailMessage = "";
         AV22SMTPServerName = "";
         AV23SMTPUserName = "";
         AV18SMTPPassword = "";
         AV21SMTPSenderName = "";
         AV20SMTPSenderAddress = "";
         AV15ServerHost = "";
         AV14ServerBaseURL = "";
         /* GeneXus formulas. */
      }

      private short AV19SMTPPort ;
      private short AV17SMTPAuthentication ;
      private short AV12MinMinutesBetweenEmails ;
      private int AV16ServerPort ;
      private string AV11MailSubject ;
      private string AV10MailMessage ;
      private string AV22SMTPServerName ;
      private string AV23SMTPUserName ;
      private string AV18SMTPPassword ;
      private string AV21SMTPSenderName ;
      private string AV20SMTPSenderAddress ;
      private string AV15ServerHost ;
      private bool AV13SendPasswordEmail ;
      private string AV14ServerBaseURL ;
      private bool aP0_SendPasswordEmail ;
      private string aP1_MailSubject ;
      private string aP2_MailMessage ;
      private string aP3_SMTPServerName ;
      private string aP4_SMTPUserName ;
      private string aP5_SMTPPassword ;
      private short aP6_SMTPPort ;
      private short aP7_SMTPAuthentication ;
      private string aP8_SMTPSenderName ;
      private string aP9_SMTPSenderAddress ;
      private short aP10_MinMinutesBetweenEmails ;
      private string aP11_ServerHost ;
      private int aP12_ServerPort ;
      private string aP13_ServerBaseURL ;
   }

}
