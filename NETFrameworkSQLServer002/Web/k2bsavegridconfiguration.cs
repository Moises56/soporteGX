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
namespace GeneXus.Programs {
   public class k2bsavegridconfiguration : GXProcedure
   {
      public k2bsavegridconfiguration( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bsavegridconfiguration( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ProgramName ,
                           string aP1_GridName ,
                           SdtK2BGridConfiguration aP2_GridConfiguration ,
                           bool aP3_PersistInDB )
      {
         this.AV11ProgramName = aP0_ProgramName;
         this.AV8GridName = aP1_GridName;
         this.AV15GridConfiguration = aP2_GridConfiguration;
         this.AV10PersistInDB = aP3_PersistInDB;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_ProgramName ,
                                 string aP1_GridName ,
                                 SdtK2BGridConfiguration aP2_GridConfiguration ,
                                 bool aP3_PersistInDB )
      {
         k2bsavegridconfiguration objk2bsavegridconfiguration;
         objk2bsavegridconfiguration = new k2bsavegridconfiguration();
         objk2bsavegridconfiguration.AV11ProgramName = aP0_ProgramName;
         objk2bsavegridconfiguration.AV8GridName = aP1_GridName;
         objk2bsavegridconfiguration.AV15GridConfiguration = aP2_GridConfiguration;
         objk2bsavegridconfiguration.AV10PersistInDB = aP3_PersistInDB;
         objk2bsavegridconfiguration.context.SetSubmitInitialConfig(context);
         objk2bsavegridconfiguration.initialize();
         Submit( executePrivateCatch,objk2bsavegridconfiguration);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bsavegridconfiguration)stateInfo).executePrivate();
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
         GXt_char1 = AV13SessionKey;
         new k2bgetgridconfigurationsessionkey(context ).execute(  AV11ProgramName,  AV8GridName, out  GXt_char1) ;
         AV13SessionKey = GXt_char1;
         AV14SessionString = AV12Session.Get(AV13SessionKey);
         AV9NewSessionString = AV15GridConfiguration.ToJSonString(false, true);
         if ( StringUtil.StrCmp(AV14SessionString, AV9NewSessionString) != 0 )
         {
            AV12Session.Set(AV13SessionKey, AV9NewSessionString);
            if ( AV10PersistInDB )
            {
               new k2bpersistgridconfiguration(context ).execute(  AV11ProgramName,  AV8GridName,  AV15GridConfiguration) ;
            }
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
         AV13SessionKey = "";
         GXt_char1 = "";
         AV14SessionString = "";
         AV12Session = context.GetSession();
         AV9NewSessionString = "";
         /* GeneXus formulas. */
      }

      private string AV11ProgramName ;
      private string AV8GridName ;
      private string AV13SessionKey ;
      private string GXt_char1 ;
      private string AV14SessionString ;
      private string AV9NewSessionString ;
      private bool AV10PersistInDB ;
      private IGxSession AV12Session ;
      private SdtK2BGridConfiguration AV15GridConfiguration ;
   }

}
