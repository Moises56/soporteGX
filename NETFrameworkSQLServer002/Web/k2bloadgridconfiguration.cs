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
   public class k2bloadgridconfiguration : GXProcedure
   {
      public k2bloadgridconfiguration( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bloadgridconfiguration( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ProgramName ,
                           string aP1_GridName ,
                           ref SdtK2BGridConfiguration aP2_GridConfiguration )
      {
         this.AV15ProgramName = aP0_ProgramName;
         this.AV14GridName = aP1_GridName;
         this.AV19GridConfiguration = aP2_GridConfiguration;
         initialize();
         executePrivate();
         aP2_GridConfiguration=this.AV19GridConfiguration;
      }

      public SdtK2BGridConfiguration executeUdp( string aP0_ProgramName ,
                                                 string aP1_GridName )
      {
         execute(aP0_ProgramName, aP1_GridName, ref aP2_GridConfiguration);
         return AV19GridConfiguration ;
      }

      public void executeSubmit( string aP0_ProgramName ,
                                 string aP1_GridName ,
                                 ref SdtK2BGridConfiguration aP2_GridConfiguration )
      {
         k2bloadgridconfiguration objk2bloadgridconfiguration;
         objk2bloadgridconfiguration = new k2bloadgridconfiguration();
         objk2bloadgridconfiguration.AV15ProgramName = aP0_ProgramName;
         objk2bloadgridconfiguration.AV14GridName = aP1_GridName;
         objk2bloadgridconfiguration.AV19GridConfiguration = aP2_GridConfiguration;
         objk2bloadgridconfiguration.context.SetSubmitInitialConfig(context);
         objk2bloadgridconfiguration.initialize();
         Submit( executePrivateCatch,objk2bloadgridconfiguration);
         aP2_GridConfiguration=this.AV19GridConfiguration;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bloadgridconfiguration)stateInfo).executePrivate();
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
         GXt_char1 = AV17SessionString;
         new k2bgetgridconfigurationsessionkey(context ).execute(  AV15ProgramName,  AV14GridName, out  GXt_char1) ;
         AV17SessionString = AV16Session.Get(GXt_char1);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17SessionString)) )
         {
            AV19GridConfiguration.FromJSonString(AV17SessionString, null);
         }
         else
         {
            AV20GridConfigurationDB.FromJSonString(AV19GridConfiguration.ToJSonString(false, true), null);
            new k2bretrievegridconfiguration(context ).execute(  AV15ProgramName,  AV14GridName, out  AV20GridConfigurationDB) ;
            AV19GridConfiguration.gxTpr_Gridcolumnsorder = AV20GridConfigurationDB.gxTpr_Gridcolumnsorder;
            AV21GXV1 = 1;
            while ( AV21GXV1 <= AV19GridConfiguration.gxTpr_Gridcolumns.Count )
            {
               AV10GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV19GridConfiguration.gxTpr_Gridcolumns.Item(AV21GXV1));
               AV8AttributeName = AV10GridColumn.gxTpr_Attributename;
               /* Execute user subroutine: 'FINDGRIDCOLUMNDB' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               if ( AV9Found )
               {
                  AV10GridColumn.gxTpr_Showattribute = AV18ShowAttribute;
               }
               AV21GXV1 = (int)(AV21GXV1+1);
            }
            AV19GridConfiguration.gxTpr_Freezecolumntitles = AV20GridConfigurationDB.gxTpr_Freezecolumntitles;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'FINDGRIDCOLUMNDB' Routine */
         returnInSub = false;
         AV9Found = false;
         AV22GXV2 = 1;
         while ( AV22GXV2 <= AV20GridConfigurationDB.gxTpr_Gridcolumns.Count )
         {
            AV11GridColumnDB = ((SdtK2BGridColumns_K2BGridColumnsItem)AV20GridConfigurationDB.gxTpr_Gridcolumns.Item(AV22GXV2));
            if ( StringUtil.StrCmp(AV11GridColumnDB.gxTpr_Attributename, AV8AttributeName) == 0 )
            {
               AV9Found = true;
               AV18ShowAttribute = AV11GridColumnDB.gxTpr_Showattribute;
               if (true) break;
            }
            AV22GXV2 = (int)(AV22GXV2+1);
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
         AV17SessionString = "";
         GXt_char1 = "";
         AV16Session = context.GetSession();
         AV20GridConfigurationDB = new SdtK2BGridConfiguration(context);
         AV10GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV8AttributeName = "";
         AV11GridColumnDB = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         /* GeneXus formulas. */
      }

      private int AV21GXV1 ;
      private int AV22GXV2 ;
      private string AV15ProgramName ;
      private string AV14GridName ;
      private string AV17SessionString ;
      private string GXt_char1 ;
      private string AV8AttributeName ;
      private bool returnInSub ;
      private bool AV9Found ;
      private bool AV18ShowAttribute ;
      private IGxSession AV16Session ;
      private SdtK2BGridConfiguration aP2_GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV10GridColumn ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV11GridColumnDB ;
      private SdtK2BGridConfiguration AV19GridConfiguration ;
      private SdtK2BGridConfiguration AV20GridConfigurationDB ;
   }

}
