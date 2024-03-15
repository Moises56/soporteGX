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
   public class checkuseractivationmethod : GXProcedure
   {
      public checkuseractivationmethod( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public checkuseractivationmethod( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserGUID ,
                           string aP1_LinkURL ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.AV10UserGUID = aP0_UserGUID;
         this.AV16LinkURL = aP1_LinkURL;
         this.AV12Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_Messages=this.AV12Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( string aP0_UserGUID ,
                                                                             string aP1_LinkURL )
      {
         execute(aP0_UserGUID, aP1_LinkURL, out aP2_Messages);
         return AV12Messages ;
      }

      public void executeSubmit( string aP0_UserGUID ,
                                 string aP1_LinkURL ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         checkuseractivationmethod objcheckuseractivationmethod;
         objcheckuseractivationmethod = new checkuseractivationmethod();
         objcheckuseractivationmethod.AV10UserGUID = aP0_UserGUID;
         objcheckuseractivationmethod.AV16LinkURL = aP1_LinkURL;
         objcheckuseractivationmethod.AV12Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objcheckuseractivationmethod.context.SetSubmitInitialConfig(context);
         objcheckuseractivationmethod.initialize();
         Submit( executePrivateCatch,objcheckuseractivationmethod);
         aP2_Messages=this.AV12Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((checkuseractivationmethod)stateInfo).executePrivate();
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
         AV9Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( StringUtil.StrCmp(AV9Repository.gxTpr_Useractivationmethod, "U") == 0 )
         {
            AV11User.load( AV10UserGUID);
            AV11User.sendemailtoactivateaccount( AV17Application,  AV16LinkURL, out  AV13Errors);
            if ( AV13Errors.Count == 0 )
            {
               AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
               AV14Message.gxTpr_Type = 0;
               AV14Message.gxTpr_Description = context.GetMessage( "K2BT_GAM_AccountCreatedPendingActivation", "");
               AV12Messages.Add(AV14Message, 0);
            }
            else
            {
               new GeneXus.Programs.k2bfsg.converterrorstomessages(context ).execute(  AV13Errors, out  AV12Messages) ;
            }
         }
         else if ( StringUtil.StrCmp(AV9Repository.gxTpr_Useractivationmethod, "D") == 0 )
         {
            AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
            AV14Message.gxTpr_Type = 0;
            AV14Message.gxTpr_Description = context.GetMessage( "K2BT_GAM_UserCreatedWaitAdmin", "");
            AV12Messages.Add(AV14Message, 0);
         }
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
         AV12Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV9Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV11User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV17Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV13Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
         /* GeneXus formulas. */
      }

      private string AV10UserGUID ;
      private string AV16LinkURL ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV13Errors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV12Messages ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV9Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV11User ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV17Application ;
      private GeneXus.Utils.SdtMessages_Message AV14Message ;
   }

}
