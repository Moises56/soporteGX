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
   public class k2bgetuseravatar : GXProcedure
   {
      public k2bgetuseravatar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bgetuseravatar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_UserImage )
      {
         this.AV8UserImage = "" ;
         initialize();
         executePrivate();
         aP0_UserImage=this.AV8UserImage;
      }

      public string executeUdp( )
      {
         execute(out aP0_UserImage);
         return AV8UserImage ;
      }

      public void executeSubmit( out string aP0_UserImage )
      {
         k2bgetuseravatar objk2bgetuseravatar;
         objk2bgetuseravatar = new k2bgetuseravatar();
         objk2bgetuseravatar.AV8UserImage = "" ;
         objk2bgetuseravatar.context.SetSubmitInitialConfig(context);
         objk2bgetuseravatar.initialize();
         Submit( executePrivateCatch,objk2bgetuseravatar);
         aP0_UserImage=this.AV8UserImage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetuseravatar)stateInfo).executePrivate();
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
         AV11GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV10GAMErrors);
         AV9GAMUser = AV11GAMSession.gxTpr_User;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9GAMUser.gxTpr_Urlimage)) || ! new GeneXus.Programs.k2btools.isvalidurl(context).executeUdp(  AV9GAMUser.gxTpr_Urlimage) )
         {
            AV8UserImage = "";
            AV13Userimage_GXI = "";
         }
         else
         {
            AV8UserImage = AV9GAMUser.gxTpr_Urlimage;
            AV13Userimage_GXI = GXDbFile.PathToUrl( AV9GAMUser.gxTpr_Urlimage);
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
         AV8UserImage = "";
         AV11GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV10GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV13Userimage_GXI = "";
         /* GeneXus formulas. */
      }

      private string AV13Userimage_GXI ;
      private string AV8UserImage ;
      private string aP0_UserImage ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV11GAMSession ;
   }

}
