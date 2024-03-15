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
   public class getmenuoptionbyname : GXProcedure
   {
      public getmenuoptionbyname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public getmenuoptionbyname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_ApplicationId ,
                           GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu aP1_ApplicationMenu ,
                           string aP2_Name ,
                           out GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption aP3_ApplicationMenuOption )
      {
         this.AV8ApplicationId = aP0_ApplicationId;
         this.AV9ApplicationMenu = aP1_ApplicationMenu;
         this.AV15Name = aP2_Name;
         this.AV10ApplicationMenuOption = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption(context) ;
         initialize();
         executePrivate();
         aP3_ApplicationMenuOption=this.AV10ApplicationMenuOption;
      }

      public GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption executeUdp( long aP0_ApplicationId ,
                                                                                      GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu aP1_ApplicationMenu ,
                                                                                      string aP2_Name )
      {
         execute(aP0_ApplicationId, aP1_ApplicationMenu, aP2_Name, out aP3_ApplicationMenuOption);
         return AV10ApplicationMenuOption ;
      }

      public void executeSubmit( long aP0_ApplicationId ,
                                 GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu aP1_ApplicationMenu ,
                                 string aP2_Name ,
                                 out GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption aP3_ApplicationMenuOption )
      {
         getmenuoptionbyname objgetmenuoptionbyname;
         objgetmenuoptionbyname = new getmenuoptionbyname();
         objgetmenuoptionbyname.AV8ApplicationId = aP0_ApplicationId;
         objgetmenuoptionbyname.AV9ApplicationMenu = aP1_ApplicationMenu;
         objgetmenuoptionbyname.AV15Name = aP2_Name;
         objgetmenuoptionbyname.AV10ApplicationMenuOption = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption(context) ;
         objgetmenuoptionbyname.context.SetSubmitInitialConfig(context);
         objgetmenuoptionbyname.initialize();
         Submit( executePrivateCatch,objgetmenuoptionbyname);
         aP3_ApplicationMenuOption=this.AV10ApplicationMenuOption;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getmenuoptionbyname)stateInfo).executePrivate();
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
         AV14MenuOptionFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOptionFilter(context);
         AV14MenuOptionFilter.gxTpr_Name = AV15Name;
         AV10ApplicationMenuOption = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption(context);
         AV17GXV2 = 1;
         AV16GXV1 = AV9ApplicationMenu.getmenuoptions(AV8ApplicationId, AV14MenuOptionFilter, out  AV12Errors);
         while ( AV17GXV2 <= AV16GXV1.Count )
         {
            AV11ApplicationMenuOptionInCollection = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption)AV16GXV1.Item(AV17GXV2));
            if ( StringUtil.StrCmp(AV11ApplicationMenuOptionInCollection.gxTpr_Name, AV15Name) == 0 )
            {
               AV10ApplicationMenuOption = AV11ApplicationMenuOptionInCollection;
               if (true) break;
            }
            AV17GXV2 = (int)(AV17GXV2+1);
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
         AV10ApplicationMenuOption = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption(context);
         AV14MenuOptionFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOptionFilter(context);
         AV16GXV1 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption", "GeneXus.Programs");
         AV12Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11ApplicationMenuOptionInCollection = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption(context);
         /* GeneXus formulas. */
      }

      private int AV17GXV2 ;
      private long AV8ApplicationId ;
      private string AV15Name ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption aP3_ApplicationMenuOption ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption> AV16GXV1 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV12Errors ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu AV9ApplicationMenu ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption AV10ApplicationMenuOption ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption AV11ApplicationMenuOptionInCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOptionFilter AV14MenuOptionFilter ;
   }

}
