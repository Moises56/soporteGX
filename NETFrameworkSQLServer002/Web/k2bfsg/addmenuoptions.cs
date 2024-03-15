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
   public class addmenuoptions : GXProcedure
   {
      public addmenuoptions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public addmenuoptions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> aP0_MenuSDT ,
                           GeneXus.Programs.genexussecurity.SdtGAMApplication aP1_Application ,
                           GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu aP2_ApplicationMenu ,
                           ref GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_Errors ,
                           ref bool aP4_Result )
      {
         this.AV15MenuSDT = aP0_MenuSDT;
         this.AV8Application = aP1_Application;
         this.AV10ApplicationMenu = aP2_ApplicationMenu;
         this.AV12Errors = aP3_Errors;
         this.AV18Result = aP4_Result;
         initialize();
         executePrivate();
         aP3_Errors=this.AV12Errors;
         aP4_Result=this.AV18Result;
      }

      public bool executeUdp( GXBaseCollection<SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> aP0_MenuSDT ,
                              GeneXus.Programs.genexussecurity.SdtGAMApplication aP1_Application ,
                              GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu aP2_ApplicationMenu ,
                              ref GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_Errors )
      {
         execute(aP0_MenuSDT, aP1_Application, aP2_ApplicationMenu, ref aP3_Errors, ref aP4_Result);
         return AV18Result ;
      }

      public void executeSubmit( GXBaseCollection<SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> aP0_MenuSDT ,
                                 GeneXus.Programs.genexussecurity.SdtGAMApplication aP1_Application ,
                                 GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu aP2_ApplicationMenu ,
                                 ref GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_Errors ,
                                 ref bool aP4_Result )
      {
         addmenuoptions objaddmenuoptions;
         objaddmenuoptions = new addmenuoptions();
         objaddmenuoptions.AV15MenuSDT = aP0_MenuSDT;
         objaddmenuoptions.AV8Application = aP1_Application;
         objaddmenuoptions.AV10ApplicationMenu = aP2_ApplicationMenu;
         objaddmenuoptions.AV12Errors = aP3_Errors;
         objaddmenuoptions.AV18Result = aP4_Result;
         objaddmenuoptions.context.SetSubmitInitialConfig(context);
         objaddmenuoptions.initialize();
         Submit( executePrivateCatch,objaddmenuoptions);
         aP3_Errors=this.AV12Errors;
         aP4_Result=this.AV18Result;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((addmenuoptions)stateInfo).executePrivate();
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
         AV18Result = true;
         /* Execute user subroutine: 'CHECKREPEATEDCODES' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( ! AV18Result )
         {
            this.cleanup();
            if (true) return;
         }
         AV22GXV1 = 1;
         while ( AV22GXV1 <= AV15MenuSDT.Count )
         {
            AV16MenuSDTItem = ((SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem)AV15MenuSDT.Item(AV22GXV1));
            if ( AV16MenuSDTItem.gxTpr_Items.Count == 0 )
            {
               GXt_SdtGAMApplicationMenuOption1 = AV11ApplicationMenuOption;
               new GeneXus.Programs.k2bfsg.getmenuoptionbyname(context ).execute(  AV8Application.gxTpr_Id,  AV10ApplicationMenu,  AV16MenuSDTItem.gxTpr_Code, out  GXt_SdtGAMApplicationMenuOption1) ;
               AV11ApplicationMenuOption = GXt_SdtGAMApplicationMenuOption1;
               GXt_boolean2 = AV14IsOK;
               new GeneXus.Programs.k2bfsg.addorupdatemenuoption(context ).execute(  AV8Application.gxTpr_Id,  AV10ApplicationMenu, ref  AV11ApplicationMenuOption,  AV16MenuSDTItem,  "S",  0, out  AV12Errors, out  GXt_boolean2) ;
               AV14IsOK = GXt_boolean2;
               if ( ! AV14IsOK )
               {
                  AV18Result = false;
                  this.cleanup();
                  if (true) return;
               }
               else
               {
                  AV18Result = true;
               }
            }
            else
            {
               GXt_boolean2 = AV14IsOK;
               new GeneXus.Programs.k2bfsg.createorupdatemenustructure(context ).execute(  AV8Application.gxTpr_Id,  AV16MenuSDTItem.gxTpr_Code,  AV16MenuSDTItem.gxTpr_Items, out  AV12Errors, out  AV19SubMenuId, out  AV17NewMenu, out  GXt_boolean2) ;
               AV14IsOK = GXt_boolean2;
               if ( ! AV14IsOK )
               {
                  AV18Result = false;
                  this.cleanup();
                  if (true) return;
               }
               GXt_SdtGAMApplicationMenuOption1 = AV11ApplicationMenuOption;
               new GeneXus.Programs.k2bfsg.getmenuoptionbyname(context ).execute(  AV8Application.gxTpr_Id,  AV10ApplicationMenu,  AV16MenuSDTItem.gxTpr_Code, out  GXt_SdtGAMApplicationMenuOption1) ;
               AV11ApplicationMenuOption = GXt_SdtGAMApplicationMenuOption1;
               GXt_boolean2 = AV14IsOK;
               new GeneXus.Programs.k2bfsg.addorupdatemenuoption(context ).execute(  AV8Application.gxTpr_Id,  AV10ApplicationMenu, ref  AV11ApplicationMenuOption,  AV16MenuSDTItem,  "M",  AV19SubMenuId, out  AV12Errors, out  GXt_boolean2) ;
               AV14IsOK = GXt_boolean2;
               if ( ! AV14IsOK )
               {
                  AV18Result = false;
               }
               else
               {
                  AV18Result = true;
               }
            }
            AV22GXV1 = (int)(AV22GXV1+1);
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKREPEATEDCODES' Routine */
         returnInSub = false;
         AV20UserCodes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23GXV2 = 1;
         while ( AV23GXV2 <= AV15MenuSDT.Count )
         {
            AV16MenuSDTItem = ((SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem)AV15MenuSDT.Item(AV23GXV2));
            if ( AV20UserCodes.IndexOf(AV16MenuSDTItem.gxTpr_Code) > 0 )
            {
               AV21Error = new GeneXus.Utils.SdtMessages_Message(context);
               AV21Error.gxTpr_Description = StringUtil.Format( context.GetMessage( "Error: duplicate code %1 in menu %2", ""), AV16MenuSDTItem.gxTpr_Code, AV10ApplicationMenu.gxTpr_Name, "", "", "", "", "", "", "");
               AV12Errors.Add(AV21Error, 0);
               AV18Result = false;
               if (true) break;
            }
            AV20UserCodes.Add(AV16MenuSDTItem.gxTpr_Code, 0);
            AV23GXV2 = (int)(AV23GXV2+1);
         }
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
         AV16MenuSDTItem = new SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem(context);
         AV11ApplicationMenuOption = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption(context);
         GXt_SdtGAMApplicationMenuOption1 = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption(context);
         AV20UserCodes = new GxSimpleCollection<string>();
         AV21Error = new GeneXus.Utils.SdtMessages_Message(context);
         /* GeneXus formulas. */
      }

      private int AV22GXV1 ;
      private int AV23GXV2 ;
      private long AV19SubMenuId ;
      private bool AV18Result ;
      private bool returnInSub ;
      private bool AV14IsOK ;
      private bool AV17NewMenu ;
      private bool GXt_boolean2 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_Errors ;
      private bool aP4_Result ;
      private GxSimpleCollection<string> AV20UserCodes ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV12Errors ;
      private GXBaseCollection<SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> AV15MenuSDT ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV8Application ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu AV10ApplicationMenu ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption AV11ApplicationMenuOption ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption GXt_SdtGAMApplicationMenuOption1 ;
      private GeneXus.Utils.SdtMessages_Message AV21Error ;
      private SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem AV16MenuSDTItem ;
   }

}
