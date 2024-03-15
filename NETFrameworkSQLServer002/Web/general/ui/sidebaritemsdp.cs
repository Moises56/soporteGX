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
namespace GeneXus.Programs.general.ui {
   public class sidebaritemsdp : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public sidebaritemsdp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public sidebaritemsdp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem>( context, "SidebarItem", "GeneXusUnanimo") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> aP0_Gxm2rootcol )
      {
         sidebaritemsdp objsidebaritemsdp;
         objsidebaritemsdp = new sidebaritemsdp();
         objsidebaritemsdp.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem>( context, "SidebarItem", "GeneXusUnanimo") ;
         objsidebaritemsdp.context.SetSubmitInitialConfig(context);
         objsidebaritemsdp.initialize();
         Submit( executePrivateCatch,objsidebaritemsdp);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sidebaritemsdp)stateInfo).executePrivate();
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
         Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
         Gxm2rootcol.Add(Gxm1sidebaritems, 0);
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
         Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
         /* GeneXus formulas. */
      }

      private GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> Gxm2rootcol ;
      private GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem Gxm1sidebaritems ;
   }

}
