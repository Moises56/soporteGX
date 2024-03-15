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
   public class isapplicationmainmenu : GXProcedure
   {
      public isapplicationmainmenu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public isapplicationmainmenu( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_ApplicationId ,
                           long aP1_MenuId ,
                           out bool aP2_IsApplicationMainMenu )
      {
         this.AV9ApplicationId = aP0_ApplicationId;
         this.AV10MenuId = aP1_MenuId;
         this.AV8IsApplicationMainMenu = false ;
         initialize();
         executePrivate();
         aP2_IsApplicationMainMenu=this.AV8IsApplicationMainMenu;
      }

      public bool executeUdp( long aP0_ApplicationId ,
                              long aP1_MenuId )
      {
         execute(aP0_ApplicationId, aP1_MenuId, out aP2_IsApplicationMainMenu);
         return AV8IsApplicationMainMenu ;
      }

      public void executeSubmit( long aP0_ApplicationId ,
                                 long aP1_MenuId ,
                                 out bool aP2_IsApplicationMainMenu )
      {
         isapplicationmainmenu objisapplicationmainmenu;
         objisapplicationmainmenu = new isapplicationmainmenu();
         objisapplicationmainmenu.AV9ApplicationId = aP0_ApplicationId;
         objisapplicationmainmenu.AV10MenuId = aP1_MenuId;
         objisapplicationmainmenu.AV8IsApplicationMainMenu = false ;
         objisapplicationmainmenu.context.SetSubmitInitialConfig(context);
         objisapplicationmainmenu.initialize();
         Submit( executePrivateCatch,objisapplicationmainmenu);
         aP2_IsApplicationMainMenu=this.AV8IsApplicationMainMenu;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((isapplicationmainmenu)stateInfo).executePrivate();
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
         AV11GAMApplication.load( AV9ApplicationId);
         if ( AV11GAMApplication.gxTpr_Mainmenuid == AV10MenuId )
         {
            AV8IsApplicationMainMenu = true;
         }
         else
         {
            AV8IsApplicationMainMenu = false;
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
         AV11GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         /* GeneXus formulas. */
      }

      private long AV9ApplicationId ;
      private long AV10MenuId ;
      private bool AV8IsApplicationMainMenu ;
      private bool aP2_IsApplicationMainMenu ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV11GAMApplication ;
   }

}
