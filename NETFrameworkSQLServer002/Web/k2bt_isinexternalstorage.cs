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
   public class k2bt_isinexternalstorage : GXProcedure
   {
      public k2bt_isinexternalstorage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bt_isinexternalstorage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_FileName ,
                           out string aP1_Uri ,
                           out bool aP2_Result )
      {
         this.AV8FileName = aP0_FileName;
         this.AV11Uri = "" ;
         this.AV9Result = false ;
         initialize();
         executePrivate();
         aP1_Uri=this.AV11Uri;
         aP2_Result=this.AV9Result;
      }

      public bool executeUdp( string aP0_FileName ,
                              out string aP1_Uri )
      {
         execute(aP0_FileName, out aP1_Uri, out aP2_Result);
         return AV9Result ;
      }

      public void executeSubmit( string aP0_FileName ,
                                 out string aP1_Uri ,
                                 out bool aP2_Result )
      {
         k2bt_isinexternalstorage objk2bt_isinexternalstorage;
         objk2bt_isinexternalstorage = new k2bt_isinexternalstorage();
         objk2bt_isinexternalstorage.AV8FileName = aP0_FileName;
         objk2bt_isinexternalstorage.AV11Uri = "" ;
         objk2bt_isinexternalstorage.AV9Result = false ;
         objk2bt_isinexternalstorage.context.SetSubmitInitialConfig(context);
         objk2bt_isinexternalstorage.initialize();
         Submit( executePrivateCatch,objk2bt_isinexternalstorage);
         aP1_Uri=this.AV11Uri;
         aP2_Result=this.AV9Result;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bt_isinexternalstorage)stateInfo).executePrivate();
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
         AV9Result = false;
         if ( AV10StorageProvider.GetPrivate(AV8FileName, AV12File, 1, AV13Messages) )
         {
            AV9Result = true;
            AV11Uri = AV12File.GetURI();
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
         AV11Uri = "";
         AV12File = new GxFile(context.GetPhysicalPath());
         AV13Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV10StorageProvider = new GxStorageProvider();
         /* GeneXus formulas. */
      }

      private string AV8FileName ;
      private bool AV9Result ;
      private string AV11Uri ;
      private GxStorageProvider AV10StorageProvider ;
      private string aP1_Uri ;
      private bool aP2_Result ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV13Messages ;
      private GxFile AV12File ;
   }

}
