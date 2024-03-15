/*
				   File: type_SdtRolesSDT_RolesSDTItem
			Description: RolesSDT
				 Author: Nemo 🐠 for C# version 18.0.5.175581
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;

using GeneXus.Programs;
namespace GeneXus.Programs.k2bfsg
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="RolesSDTItem")]
	[XmlType(TypeName="RolesSDTItem" , Namespace="test" )]
	[Serializable]
	public class SdtRolesSDT_RolesSDTItem : GxUserType
	{
		public SdtRolesSDT_RolesSDTItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtRolesSDT_RolesSDTItem_Name = "";

		}

		public SdtRolesSDT_RolesSDTItem(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("Id", gxTpr_Id, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtRolesSDT_RolesSDTItem_Name; 
			}
			set {
				gxTv_SdtRolesSDT_RolesSDTItem_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public long gxTpr_Id
		{
			get {
				return gxTv_SdtRolesSDT_RolesSDTItem_Id; 
			}
			set {
				gxTv_SdtRolesSDT_RolesSDTItem_Id = value;
				SetDirty("Id");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtRolesSDT_RolesSDTItem_Name = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtRolesSDT_RolesSDTItem_Name;
		 

		protected long gxTv_SdtRolesSDT_RolesSDTItem_Id;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"RolesSDTItem", Namespace="test")]
	public class SdtRolesSDT_RolesSDTItem_RESTInterface : GxGenericCollectionItem<SdtRolesSDT_RolesSDTItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtRolesSDT_RolesSDTItem_RESTInterface( ) : base()
		{	
		}

		public SdtRolesSDT_RolesSDTItem_RESTInterface( SdtRolesSDT_RolesSDTItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Id", Order=1)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Id, 12, 0));

			}
			set { 
				sdt.gxTpr_Id = (long) NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtRolesSDT_RolesSDTItem sdt
		{
			get { 
				return (SdtRolesSDT_RolesSDTItem)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtRolesSDT_RolesSDTItem() ;
			}
		}
	}
	#endregion
}