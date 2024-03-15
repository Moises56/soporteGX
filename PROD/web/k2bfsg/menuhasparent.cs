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
   public class menuhasparent : GXProcedure
   {
      public menuhasparent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public menuhasparent( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_ApplicationId ,
                           long aP1_MenuId ,
                           out bool aP2_hasParent )
      {
         this.AV8ApplicationId = aP0_ApplicationId;
         this.AV15MenuId = aP1_MenuId;
         this.AV12hasParent = false ;
         initialize();
         executePrivate();
         aP2_hasParent=this.AV12hasParent;
      }

      public bool executeUdp( long aP0_ApplicationId ,
                              long aP1_MenuId )
      {
         execute(aP0_ApplicationId, aP1_MenuId, out aP2_hasParent);
         return AV12hasParent ;
      }

      public void executeSubmit( long aP0_ApplicationId ,
                                 long aP1_MenuId ,
                                 out bool aP2_hasParent )
      {
         menuhasparent objmenuhasparent;
         objmenuhasparent = new menuhasparent();
         objmenuhasparent.AV8ApplicationId = aP0_ApplicationId;
         objmenuhasparent.AV15MenuId = aP1_MenuId;
         objmenuhasparent.AV12hasParent = false ;
         objmenuhasparent.context.SetSubmitInitialConfig(context);
         objmenuhasparent.initialize();
         Submit( executePrivateCatch,objmenuhasparent);
         aP2_hasParent=this.AV12hasParent;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((menuhasparent)stateInfo).executePrivate();
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
         AV10GAMApplication.load( AV8ApplicationId);
         AV14MenuFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuFilter(context);
         AV19Menus = AV10GAMApplication.getmenus(AV14MenuFilter, out  AV9Errors);
         AV12hasParent = false;
         AV21GXV1 = 1;
         while ( AV21GXV1 <= AV19Menus.Count )
         {
            AV13Menu = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu)AV19Menus.Item(AV21GXV1));
            if ( AV13Menu.gxTpr_Id != AV15MenuId )
            {
               AV17MenuOptionFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOptionFilter(context);
               AV18MenuOptions = AV13Menu.getmenuoptions(AV8ApplicationId, AV17MenuOptionFilter, out  AV9Errors);
               AV22GXV2 = 1;
               while ( AV22GXV2 <= AV18MenuOptions.Count )
               {
                  AV16MenuOption = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption)AV18MenuOptions.Item(AV22GXV2));
                  if ( StringUtil.StrCmp(AV16MenuOption.gxTpr_Type, "M") == 0 )
                  {
                     AV20ApplicationMenuOption = AV10GAMApplication.getmenuoption(AV13Menu.gxTpr_Id, AV16MenuOption.gxTpr_Id, out  AV9Errors);
                     if ( AV20ApplicationMenuOption.gxTpr_Submenuid == AV15MenuId )
                     {
                        AV12hasParent = true;
                        if (true) break;
                     }
                  }
                  AV22GXV2 = (int)(AV22GXV2+1);
               }
            }
            if ( AV12hasParent )
            {
               if (true) break;
            }
            AV21GXV1 = (int)(AV21GXV1+1);
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
         AV10GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV14MenuFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuFilter(context);
         AV19Menus = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu", "GeneXus.Programs");
         AV9Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV13Menu = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu(context);
         AV17MenuOptionFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOptionFilter(context);
         AV18MenuOptions = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption", "GeneXus.Programs");
         AV16MenuOption = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption(context);
         AV20ApplicationMenuOption = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption(context);
         /* GeneXus formulas. */
      }

      private int AV21GXV1 ;
      private int AV22GXV2 ;
      private long AV8ApplicationId ;
      private long AV15MenuId ;
      private bool AV12hasParent ;
      private bool aP2_hasParent ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu> AV19Menus ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption> AV18MenuOptions ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV10GAMApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu AV13Menu ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption AV16MenuOption ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption AV20ApplicationMenuOption ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOptionFilter AV17MenuOptionFilter ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuFilter AV14MenuFilter ;
   }

}
