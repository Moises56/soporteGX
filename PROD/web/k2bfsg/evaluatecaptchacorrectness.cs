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
   public class evaluatecaptchacorrectness : GXProcedure
   {
      public evaluatecaptchacorrectness( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public evaluatecaptchacorrectness( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_CaptchaText ,
                           out bool aP1_CaptchaIsCorrect )
      {
         this.AV10CaptchaText = aP0_CaptchaText;
         this.AV8CaptchaIsCorrect = false ;
         initialize();
         executePrivate();
         aP1_CaptchaIsCorrect=this.AV8CaptchaIsCorrect;
      }

      public bool executeUdp( string aP0_CaptchaText )
      {
         execute(aP0_CaptchaText, out aP1_CaptchaIsCorrect);
         return AV8CaptchaIsCorrect ;
      }

      public void executeSubmit( string aP0_CaptchaText ,
                                 out bool aP1_CaptchaIsCorrect )
      {
         evaluatecaptchacorrectness objevaluatecaptchacorrectness;
         objevaluatecaptchacorrectness = new evaluatecaptchacorrectness();
         objevaluatecaptchacorrectness.AV10CaptchaText = aP0_CaptchaText;
         objevaluatecaptchacorrectness.AV8CaptchaIsCorrect = false ;
         objevaluatecaptchacorrectness.context.SetSubmitInitialConfig(context);
         objevaluatecaptchacorrectness.initialize();
         Submit( executePrivateCatch,objevaluatecaptchacorrectness);
         aP1_CaptchaIsCorrect=this.AV8CaptchaIsCorrect;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((evaluatecaptchacorrectness)stateInfo).executePrivate();
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
         new k2bsessionget(context ).execute(  "SessionCaptchaIteSessionCaptchaItem", out  AV9CaptchaRequiredText) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9CaptchaRequiredText)) )
         {
            AV8CaptchaIsCorrect = false;
         }
         else
         {
            if ( StringUtil.StrCmp(AV9CaptchaRequiredText, AV10CaptchaText) == 0 )
            {
               AV8CaptchaIsCorrect = true;
            }
            else
            {
               AV8CaptchaIsCorrect = false;
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
         AV9CaptchaRequiredText = "";
         /* GeneXus formulas. */
      }

      private string AV10CaptchaText ;
      private string AV9CaptchaRequiredText ;
      private bool AV8CaptchaIsCorrect ;
      private bool aP1_CaptchaIsCorrect ;
   }

}
