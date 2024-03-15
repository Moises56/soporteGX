using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
   public class loadapplicationpermissions : GXProcedure
   {
      public loadapplicationpermissions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public loadapplicationpermissions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ApplicationId ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP1_Messages )
      {
         this.AV12ApplicationId = aP0_ApplicationId;
         this.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP1_Messages=this.AV9Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( long aP0_ApplicationId )
      {
         execute(aP0_ApplicationId, out aP1_Messages);
         return AV9Messages ;
      }

      public void executeSubmit( long aP0_ApplicationId ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP1_Messages )
      {
         loadapplicationpermissions objloadapplicationpermissions;
         objloadapplicationpermissions = new loadapplicationpermissions();
         objloadapplicationpermissions.AV12ApplicationId = aP0_ApplicationId;
         objloadapplicationpermissions.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objloadapplicationpermissions.context.SetSubmitInitialConfig(context);
         objloadapplicationpermissions.initialize();
         Submit( executePrivateCatch,objloadapplicationpermissions);
         aP1_Messages=this.AV9Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadapplicationpermissions)stateInfo).executePrivate();
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
         GXt_objcol_SdtK2BActivityList_K2BActivityListItem1 = AV11ActivityList;
         new k2bloadactivitylist(context ).execute( out  GXt_objcol_SdtK2BActivityList_K2BActivityListItem1) ;
         AV11ActivityList = GXt_objcol_SdtK2BActivityList_K2BActivityListItem1;
         AV19correctInserts = 0;
         AV20failedInserts = 0;
         AV21existingPermissions = 0;
         AV8GAMApplication.load( AV12ApplicationId);
         AV22GXV1 = 1;
         while ( AV22GXV1 <= AV11ActivityList.Count )
         {
            AV10Activity = ((SdtK2BActivityList_K2BActivityListItem)AV11ActivityList.Item(AV22GXV1));
            if ( StringUtil.StrCmp(AV10Activity.gxTpr_Activity.gxTpr_Standardactivitytype, "Maintenance") != 0 )
            {
               GXt_char2 = AV17permissionName;
               new GeneXus.Programs.k2bfsg.getgampermissionnameforactivity(context ).execute(  AV10Activity.gxTpr_Activity, out  GXt_char2) ;
               AV17permissionName = GXt_char2;
               AV13ApplicationPermission = AV8GAMApplication.getpermissionbyname(AV17permissionName, out  AV15Errors);
               if ( ( AV15Errors.Count == 1 ) && ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV15Errors.Item(1)).gxTpr_Code == 153 ) )
               {
                  AV13ApplicationPermission.gxTpr_Name = AV17permissionName;
                  AV13ApplicationPermission.gxTpr_Description = AV17permissionName;
                  AV13ApplicationPermission.gxTpr_Accesstype = "R";
                  AV18isOK = AV8GAMApplication.addpermission(AV13ApplicationPermission, out  AV15Errors);
                  if ( AV18isOK )
                  {
                     AV16Message = new GeneXus.Utils.SdtMessages_Message(context);
                     AV16Message.gxTpr_Description = StringUtil.Format( context.GetMessage( "K2BT_GAM_PermissionAddedSuccessfully", ""), AV17permissionName, "", "", "", "", "", "", "", "");
                     AV9Messages.Add(AV16Message, 0);
                     AV19correctInserts = (short)(AV19correctInserts+1);
                  }
                  else
                  {
                     if ( AV15Errors.Count > 0 )
                     {
                        AV16Message = new GeneXus.Utils.SdtMessages_Message(context);
                        AV16Message.gxTpr_Description = StringUtil.Format( context.GetMessage( "K2BT_GAM_ErrorWhenAddingPermission", ""), AV17permissionName, "", "", "", "", "", "", "", "");
                        AV9Messages.Add(AV16Message, 0);
                        /* Execute user subroutine: 'ADDERRORSTOMESSAGES' */
                        S111 ();
                        if ( returnInSub )
                        {
                           this.cleanup();
                           if (true) return;
                        }
                     }
                     AV20failedInserts = (short)(AV20failedInserts+1);
                  }
               }
               else
               {
                  if ( AV15Errors.Count == 0 )
                  {
                     AV21existingPermissions = (short)(AV21existingPermissions+1);
                  }
                  else
                  {
                     AV20failedInserts = (short)(AV20failedInserts+1);
                  }
               }
            }
            AV22GXV1 = (int)(AV22GXV1+1);
         }
         AV16Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV16Message.gxTpr_Description = StringUtil.Format( context.GetMessage( "K2BT_GAM_LoadPermissionsResult", ""), StringUtil.LTrimStr( (decimal)(AV19correctInserts), 4, 0), StringUtil.LTrimStr( (decimal)(AV20failedInserts), 4, 0), StringUtil.LTrimStr( (decimal)(AV21existingPermissions), 4, 0), "", "", "", "", "", "");
         AV9Messages.Add(AV16Message, 0);
         context.CommitDataStores("k2bfsg.loadapplicationpermissions",pr_default);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'ADDERRORSTOMESSAGES' Routine */
         returnInSub = false;
         AV23GXV2 = 1;
         while ( AV23GXV2 <= AV15Errors.Count )
         {
            AV14Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV15Errors.Item(AV23GXV2));
            AV16Message = new GeneXus.Utils.SdtMessages_Message(context);
            AV16Message.gxTpr_Id = StringUtil.Str( (decimal)(AV14Error.gxTpr_Code), 12, 0);
            AV16Message.gxTpr_Description = AV14Error.gxTpr_Message;
            AV9Messages.Add(AV16Message, 0);
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
         AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV11ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "test");
         GXt_objcol_SdtK2BActivityList_K2BActivityListItem1 = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "test");
         AV8GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV10Activity = new SdtK2BActivityList_K2BActivityListItem(context);
         AV17permissionName = "";
         GXt_char2 = "";
         AV13ApplicationPermission = new GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission(context);
         AV15Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV16Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV14Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.loadapplicationpermissions__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.loadapplicationpermissions__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19correctInserts ;
      private short AV20failedInserts ;
      private short AV21existingPermissions ;
      private int AV22GXV1 ;
      private int AV23GXV2 ;
      private long AV12ApplicationId ;
      private string AV17permissionName ;
      private string GXt_char2 ;
      private bool AV18isOK ;
      private bool returnInSub ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP1_Messages ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV15Errors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9Messages ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV11ActivityList ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> GXt_objcol_SdtK2BActivityList_K2BActivityListItem1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV8GAMApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV14Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission AV13ApplicationPermission ;
      private GeneXus.Utils.SdtMessages_Message AV16Message ;
      private SdtK2BActivityList_K2BActivityListItem AV10Activity ;
   }

   public class loadapplicationpermissions__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class loadapplicationpermissions__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}
