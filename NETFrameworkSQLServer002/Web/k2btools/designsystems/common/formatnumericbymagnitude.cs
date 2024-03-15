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
namespace GeneXus.Programs.k2btools.designsystems.common {
   public class formatnumericbymagnitude : GXProcedure
   {
      public formatnumericbymagnitude( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public formatnumericbymagnitude( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_Number ,
                           out string aP1_Result )
      {
         this.AV8Number = aP0_Number;
         this.AV9Result = "" ;
         initialize();
         executePrivate();
         aP1_Result=this.AV9Result;
      }

      public string executeUdp( long aP0_Number )
      {
         execute(aP0_Number, out aP1_Result);
         return AV9Result ;
      }

      public void executeSubmit( long aP0_Number ,
                                 out string aP1_Result )
      {
         formatnumericbymagnitude objformatnumericbymagnitude;
         objformatnumericbymagnitude = new formatnumericbymagnitude();
         objformatnumericbymagnitude.AV8Number = aP0_Number;
         objformatnumericbymagnitude.AV9Result = "" ;
         objformatnumericbymagnitude.context.SetSubmitInitialConfig(context);
         objformatnumericbymagnitude.initialize();
         Submit( executePrivateCatch,objformatnumericbymagnitude);
         aP1_Result=this.AV9Result;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((formatnumericbymagnitude)stateInfo).executePrivate();
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
         if ( AV8Number < 1000 )
         {
            AV9Result = context.localUtil.Format( (decimal)(AV8Number), "ZZZ,ZZZ,ZZZ,ZZZ,ZZZ,ZZ9");
         }
         else if ( AV8Number < 10000 )
         {
            AV10NumberWithDecimals = (decimal)(AV8Number/ (decimal)(1000));
            AV9Result = context.localUtil.Format( AV10NumberWithDecimals, "Z9.9") + "K";
         }
         else if ( AV8Number < 1000000 )
         {
            AV11TmpNumber = (long)(AV8Number/ (decimal)(1000));
            AV9Result = context.localUtil.Format( (decimal)(AV11TmpNumber), "ZZZ,ZZZ,ZZZ,ZZZ,ZZZ,ZZ9") + "K";
         }
         else if ( AV8Number < 10000000 )
         {
            AV10NumberWithDecimals = (decimal)(AV8Number/ (decimal)(1000000));
            AV9Result = context.localUtil.Format( AV10NumberWithDecimals, "Z9.9") + "M";
         }
         else
         {
            AV11TmpNumber = (long)(AV8Number/ (decimal)(1000000));
            AV9Result = context.localUtil.Format( (decimal)(AV11TmpNumber), "ZZZ,ZZZ,ZZZ,ZZZ,ZZZ,ZZ9") + "M";
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
         AV9Result = "";
         /* GeneXus formulas. */
      }

      private long AV8Number ;
      private long AV11TmpNumber ;
      private decimal AV10NumberWithDecimals ;
      private string AV9Result ;
      private string aP1_Result ;
   }

}
