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
namespace GeneXus.Programs.k2btools.tabbedview {
   public class gettabsmarkup : GXProcedure
   {
      public gettabsmarkup( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public gettabsmarkup( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem> aP0_Tabs ,
                           short aP1_FirstTab ,
                           short aP2_LastTab ,
                           short aP3_SelectedTab ,
                           string aP4_Gx_mode ,
                           out string aP5_TabsMarkup )
      {
         this.AV11Tabs = aP0_Tabs;
         this.AV9FirstTab = aP1_FirstTab;
         this.AV10LastTab = aP2_LastTab;
         this.AV15SelectedTab = aP3_SelectedTab;
         this.Gx_mode = aP4_Gx_mode;
         this.AV8TabsMarkup = "" ;
         initialize();
         executePrivate();
         aP5_TabsMarkup=this.AV8TabsMarkup;
      }

      public string executeUdp( GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem> aP0_Tabs ,
                                short aP1_FirstTab ,
                                short aP2_LastTab ,
                                short aP3_SelectedTab ,
                                string aP4_Gx_mode )
      {
         execute(aP0_Tabs, aP1_FirstTab, aP2_LastTab, aP3_SelectedTab, aP4_Gx_mode, out aP5_TabsMarkup);
         return AV8TabsMarkup ;
      }

      public void executeSubmit( GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem> aP0_Tabs ,
                                 short aP1_FirstTab ,
                                 short aP2_LastTab ,
                                 short aP3_SelectedTab ,
                                 string aP4_Gx_mode ,
                                 out string aP5_TabsMarkup )
      {
         gettabsmarkup objgettabsmarkup;
         objgettabsmarkup = new gettabsmarkup();
         objgettabsmarkup.AV11Tabs = aP0_Tabs;
         objgettabsmarkup.AV9FirstTab = aP1_FirstTab;
         objgettabsmarkup.AV10LastTab = aP2_LastTab;
         objgettabsmarkup.AV15SelectedTab = aP3_SelectedTab;
         objgettabsmarkup.Gx_mode = aP4_Gx_mode;
         objgettabsmarkup.AV8TabsMarkup = "" ;
         objgettabsmarkup.context.SetSubmitInitialConfig(context);
         objgettabsmarkup.initialize();
         Submit( executePrivateCatch,objgettabsmarkup);
         aP5_TabsMarkup=this.AV8TabsMarkup;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gettabsmarkup)stateInfo).executePrivate();
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
         AV8TabsMarkup = "";
         AV13Index = AV9FirstTab;
         while ( AV13Index <= AV10LastTab )
         {
            AV12Tab = ((SdtK2BTabOptions_K2BTabOptionsItem)AV11Tabs.Item(AV13Index));
            if ( AV13Index == AV15SelectedTab )
            {
               AV14TabTemplate = "<li class=\"%1\">" + "<span id=\"%2Tab\">%3</span>" + "</li>";
               AV8TabsMarkup += StringUtil.Format( AV14TabTemplate, "K2BT_TabItemSelected", AV12Tab.gxTpr_Code, AV12Tab.gxTpr_Description, "", "", "", "", "", "");
            }
            else
            {
               if ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 )
               {
                  AV14TabTemplate = "<li class=\"%1\">" + "<span id=\"%2Tab\">%3</span>" + "</li>";
                  AV8TabsMarkup += StringUtil.Format( AV14TabTemplate, "K2BT_TabItem", AV12Tab.gxTpr_Code, AV12Tab.gxTpr_Description, "", "", "", "", "", "");
               }
               else
               {
                  AV14TabTemplate = "<li class=\"%1\">" + "<a id=\"%2Tab\" href=\"%3\">%4</a>" + "</li>";
                  AV8TabsMarkup += StringUtil.Format( AV14TabTemplate, "K2BT_TabItem", AV12Tab.gxTpr_Code, AV12Tab.gxTpr_Link, AV12Tab.gxTpr_Description, "", "", "", "", "");
               }
            }
            AV13Index = (short)(AV13Index+1);
         }
         AV8TabsMarkup = StringUtil.Format( "<ul class=\"%2\">%1</ul>", AV8TabsMarkup, "K2BT_Tab", "", "", "", "", "", "", "");
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
         AV8TabsMarkup = "";
         AV12Tab = new SdtK2BTabOptions_K2BTabOptionsItem(context);
         AV14TabTemplate = "";
         /* GeneXus formulas. */
      }

      private short AV9FirstTab ;
      private short AV10LastTab ;
      private short AV15SelectedTab ;
      private short AV13Index ;
      private string Gx_mode ;
      private string AV8TabsMarkup ;
      private string AV14TabTemplate ;
      private string aP5_TabsMarkup ;
      private GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem> AV11Tabs ;
      private SdtK2BTabOptions_K2BTabOptionsItem AV12Tab ;
   }

}
