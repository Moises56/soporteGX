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
   public class getmenubyname : GXProcedure
   {
      public getmenubyname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public getmenubyname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.genexussecurity.SdtGAMApplication aP0_Application ,
                           string aP1_Name ,
                           out GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu aP2_ApplicationMenu )
      {
         this.AV8Application = aP0_Application;
         this.AV11Name = aP1_Name;
         this.AV9ApplicationMenu = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu(context) ;
         initialize();
         executePrivate();
         aP2_ApplicationMenu=this.AV9ApplicationMenu;
      }

      public GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu executeUdp( GeneXus.Programs.genexussecurity.SdtGAMApplication aP0_Application ,
                                                                                string aP1_Name )
      {
         execute(aP0_Application, aP1_Name, out aP2_ApplicationMenu);
         return AV9ApplicationMenu ;
      }

      public void executeSubmit( GeneXus.Programs.genexussecurity.SdtGAMApplication aP0_Application ,
                                 string aP1_Name ,
                                 out GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu aP2_ApplicationMenu )
      {
         getmenubyname objgetmenubyname;
         objgetmenubyname = new getmenubyname();
         objgetmenubyname.AV8Application = aP0_Application;
         objgetmenubyname.AV11Name = aP1_Name;
         objgetmenubyname.AV9ApplicationMenu = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu(context) ;
         objgetmenubyname.context.SetSubmitInitialConfig(context);
         objgetmenubyname.initialize();
         Submit( executePrivateCatch,objgetmenubyname);
         aP2_ApplicationMenu=this.AV9ApplicationMenu;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getmenubyname)stateInfo).executePrivate();
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
         AV13MenuFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuFilter(context);
         AV13MenuFilter.gxTpr_Name = AV11Name;
         AV15GXV2 = 1;
         AV14GXV1 = AV8Application.getmenus(AV13MenuFilter, out  AV12GAMErrors);
         while ( AV15GXV2 <= AV14GXV1.Count )
         {
            AV10ApplicationMenuItem = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu)AV14GXV1.Item(AV15GXV2));
            if ( StringUtil.StrCmp(AV10ApplicationMenuItem.gxTpr_Name, AV11Name) == 0 )
            {
               AV9ApplicationMenu = AV10ApplicationMenuItem;
               if (true) break;
            }
            AV15GXV2 = (int)(AV15GXV2+1);
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
         AV9ApplicationMenu = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu(context);
         AV13MenuFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuFilter(context);
         AV14GXV1 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu", "GeneXus.Programs");
         AV12GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10ApplicationMenuItem = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu(context);
         /* GeneXus formulas. */
      }

      private int AV15GXV2 ;
      private string AV11Name ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu aP2_ApplicationMenu ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV12GAMErrors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu> AV14GXV1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV8Application ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu AV9ApplicationMenu ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu AV10ApplicationMenuItem ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuFilter AV13MenuFilter ;
   }

}
