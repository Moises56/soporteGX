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
   public class getgampermissionnameforactivity : GXProcedure
   {
      public getgampermissionnameforactivity( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public getgampermissionnameforactivity( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtK2BActivity aP0_activity ,
                           out string aP1_activityToCheck )
      {
         this.AV8activity = aP0_activity;
         this.AV9activityToCheck = "" ;
         initialize();
         executePrivate();
         aP1_activityToCheck=this.AV9activityToCheck;
      }

      public string executeUdp( SdtK2BActivity aP0_activity )
      {
         execute(aP0_activity, out aP1_activityToCheck);
         return AV9activityToCheck ;
      }

      public void executeSubmit( SdtK2BActivity aP0_activity ,
                                 out string aP1_activityToCheck )
      {
         getgampermissionnameforactivity objgetgampermissionnameforactivity;
         objgetgampermissionnameforactivity = new getgampermissionnameforactivity();
         objgetgampermissionnameforactivity.AV8activity = aP0_activity;
         objgetgampermissionnameforactivity.AV9activityToCheck = "" ;
         objgetgampermissionnameforactivity.context.SetSubmitInitialConfig(context);
         objgetgampermissionnameforactivity.initialize();
         Submit( executePrivateCatch,objgetgampermissionnameforactivity);
         aP1_activityToCheck=this.AV9activityToCheck;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getgampermissionnameforactivity)stateInfo).executePrivate();
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8activity.gxTpr_Entityname)) )
         {
            AV9activityToCheck = StringUtil.Lower( StringUtil.Trim( AV8activity.gxTpr_Entityname)) + "_";
         }
         else
         {
            AV9activityToCheck = "";
         }
         AV9activityToCheck = StringUtil.Lower( AV9activityToCheck);
         if ( StringUtil.StrCmp(AV8activity.gxTpr_Standardactivitytype, "Insert") == 0 )
         {
            AV9activityToCheck += "Insert";
         }
         else if ( StringUtil.StrCmp(AV8activity.gxTpr_Standardactivitytype, "Update") == 0 )
         {
            AV9activityToCheck += "Update";
         }
         else if ( StringUtil.StrCmp(AV8activity.gxTpr_Standardactivitytype, "Delete") == 0 )
         {
            AV9activityToCheck += "Delete";
         }
         else if ( StringUtil.StrCmp(AV8activity.gxTpr_Standardactivitytype, "Display") == 0 )
         {
            AV9activityToCheck += "Execute";
         }
         else if ( StringUtil.StrCmp(AV8activity.gxTpr_Standardactivitytype, "List") == 0 )
         {
            AV9activityToCheck += "Execute";
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8activity.gxTpr_Useractivitytype)) )
            {
               AV9activityToCheck = StringUtil.Lower( AV8activity.gxTpr_Useractivitytype) + "_Execute";
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
         AV9activityToCheck = "";
         /* GeneXus formulas. */
      }

      private string AV9activityToCheck ;
      private string aP1_activityToCheck ;
      private SdtK2BActivity AV8activity ;
   }

}
