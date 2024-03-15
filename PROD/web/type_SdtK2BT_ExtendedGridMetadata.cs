/*
				   File: type_SdtK2BT_ExtendedGridMetadata
			Description: K2BT_ExtendedGridMetadata
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


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="K2BT_ExtendedGridMetadata")]
	[XmlType(TypeName="K2BT_ExtendedGridMetadata" , Namespace="test" )]
	[Serializable]
	public class SdtK2BT_ExtendedGridMetadata : GxUserType
	{
		public SdtK2BT_ExtendedGridMetadata( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BT_ExtendedGridMetadata_Overflowactionposition = "";

			gxTv_SdtK2BT_ExtendedGridMetadata_Rowselectionflagcolumnname = "";

		}

		public SdtK2BT_ExtendedGridMetadata(IGxContext context)
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
			if (gxTv_SdtK2BT_ExtendedGridMetadata_Columns != null)
			{
				AddObjectProperty("Columns", gxTv_SdtK2BT_ExtendedGridMetadata_Columns, false);
			}
			if (gxTv_SdtK2BT_ExtendedGridMetadata_Actiongroups != null)
			{
				AddObjectProperty("ActionGroups", gxTv_SdtK2BT_ExtendedGridMetadata_Actiongroups, false);
			}
			if (gxTv_SdtK2BT_ExtendedGridMetadata_Columngroups != null)
			{
				AddObjectProperty("ColumnGroups", gxTv_SdtK2BT_ExtendedGridMetadata_Columngroups, false);
			}

			AddObjectProperty("OverflowActionPosition", gxTpr_Overflowactionposition, false);


			AddObjectProperty("RowSelectionFlagColumnName", gxTpr_Rowselectionflagcolumnname, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Columns" )]
		[XmlArray(ElementName="Columns"  )]
		[XmlArrayItemAttribute(ElementName="Column" , IsNullable=false )]
		public GXBaseCollection<SdtK2BT_ExtendedGridMetadata_Column> gxTpr_Columns
		{
			get {
				if ( gxTv_SdtK2BT_ExtendedGridMetadata_Columns == null )
				{
					gxTv_SdtK2BT_ExtendedGridMetadata_Columns = new GXBaseCollection<SdtK2BT_ExtendedGridMetadata_Column>( context, "K2BT_ExtendedGridMetadata.Column", "");
				}
				return gxTv_SdtK2BT_ExtendedGridMetadata_Columns;
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_Columns_N = false;
				gxTv_SdtK2BT_ExtendedGridMetadata_Columns = value;
				SetDirty("Columns");
			}
		}

		public void gxTv_SdtK2BT_ExtendedGridMetadata_Columns_SetNull()
		{
			gxTv_SdtK2BT_ExtendedGridMetadata_Columns_N = true;
			gxTv_SdtK2BT_ExtendedGridMetadata_Columns = null;
		}

		public bool gxTv_SdtK2BT_ExtendedGridMetadata_Columns_IsNull()
		{
			return gxTv_SdtK2BT_ExtendedGridMetadata_Columns == null;
		}
		public bool ShouldSerializegxTpr_Columns_GxSimpleCollection_Json()
		{
			return gxTv_SdtK2BT_ExtendedGridMetadata_Columns != null && gxTv_SdtK2BT_ExtendedGridMetadata_Columns.Count > 0;

		}



		[SoapElement(ElementName="ActionGroups" )]
		[XmlArray(ElementName="ActionGroups"  )]
		[XmlArrayItemAttribute(ElementName="ActionGroup" , IsNullable=false )]
		public GXBaseCollection<SdtK2BT_ExtendedGridMetadata_ActionGroup> gxTpr_Actiongroups
		{
			get {
				if ( gxTv_SdtK2BT_ExtendedGridMetadata_Actiongroups == null )
				{
					gxTv_SdtK2BT_ExtendedGridMetadata_Actiongroups = new GXBaseCollection<SdtK2BT_ExtendedGridMetadata_ActionGroup>( context, "K2BT_ExtendedGridMetadata.ActionGroup", "");
				}
				return gxTv_SdtK2BT_ExtendedGridMetadata_Actiongroups;
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_Actiongroups_N = false;
				gxTv_SdtK2BT_ExtendedGridMetadata_Actiongroups = value;
				SetDirty("Actiongroups");
			}
		}

		public void gxTv_SdtK2BT_ExtendedGridMetadata_Actiongroups_SetNull()
		{
			gxTv_SdtK2BT_ExtendedGridMetadata_Actiongroups_N = true;
			gxTv_SdtK2BT_ExtendedGridMetadata_Actiongroups = null;
		}

		public bool gxTv_SdtK2BT_ExtendedGridMetadata_Actiongroups_IsNull()
		{
			return gxTv_SdtK2BT_ExtendedGridMetadata_Actiongroups == null;
		}
		public bool ShouldSerializegxTpr_Actiongroups_GxSimpleCollection_Json()
		{
			return gxTv_SdtK2BT_ExtendedGridMetadata_Actiongroups != null && gxTv_SdtK2BT_ExtendedGridMetadata_Actiongroups.Count > 0;

		}



		[SoapElement(ElementName="ColumnGroups" )]
		[XmlArray(ElementName="ColumnGroups"  )]
		[XmlArrayItemAttribute(ElementName="ColumnGroup" , IsNullable=false )]
		public GXBaseCollection<SdtK2BT_ExtendedGridMetadata_ColumnGroup> gxTpr_Columngroups
		{
			get {
				if ( gxTv_SdtK2BT_ExtendedGridMetadata_Columngroups == null )
				{
					gxTv_SdtK2BT_ExtendedGridMetadata_Columngroups = new GXBaseCollection<SdtK2BT_ExtendedGridMetadata_ColumnGroup>( context, "K2BT_ExtendedGridMetadata.ColumnGroup", "");
				}
				return gxTv_SdtK2BT_ExtendedGridMetadata_Columngroups;
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_Columngroups_N = false;
				gxTv_SdtK2BT_ExtendedGridMetadata_Columngroups = value;
				SetDirty("Columngroups");
			}
		}

		public void gxTv_SdtK2BT_ExtendedGridMetadata_Columngroups_SetNull()
		{
			gxTv_SdtK2BT_ExtendedGridMetadata_Columngroups_N = true;
			gxTv_SdtK2BT_ExtendedGridMetadata_Columngroups = null;
		}

		public bool gxTv_SdtK2BT_ExtendedGridMetadata_Columngroups_IsNull()
		{
			return gxTv_SdtK2BT_ExtendedGridMetadata_Columngroups == null;
		}
		public bool ShouldSerializegxTpr_Columngroups_GxSimpleCollection_Json()
		{
			return gxTv_SdtK2BT_ExtendedGridMetadata_Columngroups != null && gxTv_SdtK2BT_ExtendedGridMetadata_Columngroups.Count > 0;

		}



		[SoapElement(ElementName="OverflowActionPosition")]
		[XmlElement(ElementName="OverflowActionPosition")]
		public string gxTpr_Overflowactionposition
		{
			get {
				return gxTv_SdtK2BT_ExtendedGridMetadata_Overflowactionposition; 
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_Overflowactionposition = value;
				SetDirty("Overflowactionposition");
			}
		}




		[SoapElement(ElementName="RowSelectionFlagColumnName")]
		[XmlElement(ElementName="RowSelectionFlagColumnName")]
		public string gxTpr_Rowselectionflagcolumnname
		{
			get {
				return gxTv_SdtK2BT_ExtendedGridMetadata_Rowselectionflagcolumnname; 
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_Rowselectionflagcolumnname = value;
				SetDirty("Rowselectionflagcolumnname");
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
			gxTv_SdtK2BT_ExtendedGridMetadata_Columns_N = true;


			gxTv_SdtK2BT_ExtendedGridMetadata_Actiongroups_N = true;


			gxTv_SdtK2BT_ExtendedGridMetadata_Columngroups_N = true;

			gxTv_SdtK2BT_ExtendedGridMetadata_Overflowactionposition = "";
			gxTv_SdtK2BT_ExtendedGridMetadata_Rowselectionflagcolumnname = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtK2BT_ExtendedGridMetadata_Columns_N;
		protected GXBaseCollection<SdtK2BT_ExtendedGridMetadata_Column> gxTv_SdtK2BT_ExtendedGridMetadata_Columns = null; 

		protected bool gxTv_SdtK2BT_ExtendedGridMetadata_Actiongroups_N;
		protected GXBaseCollection<SdtK2BT_ExtendedGridMetadata_ActionGroup> gxTv_SdtK2BT_ExtendedGridMetadata_Actiongroups = null; 

		protected bool gxTv_SdtK2BT_ExtendedGridMetadata_Columngroups_N;
		protected GXBaseCollection<SdtK2BT_ExtendedGridMetadata_ColumnGroup> gxTv_SdtK2BT_ExtendedGridMetadata_Columngroups = null; 


		protected string gxTv_SdtK2BT_ExtendedGridMetadata_Overflowactionposition;
		 

		protected string gxTv_SdtK2BT_ExtendedGridMetadata_Rowselectionflagcolumnname;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"K2BT_ExtendedGridMetadata", Namespace="test")]
	public class SdtK2BT_ExtendedGridMetadata_RESTInterface : GxGenericCollectionItem<SdtK2BT_ExtendedGridMetadata>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BT_ExtendedGridMetadata_RESTInterface( ) : base()
		{	
		}

		public SdtK2BT_ExtendedGridMetadata_RESTInterface( SdtK2BT_ExtendedGridMetadata psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Columns", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtK2BT_ExtendedGridMetadata_Column_RESTInterface> gxTpr_Columns
		{
			get {
				if (sdt.ShouldSerializegxTpr_Columns_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtK2BT_ExtendedGridMetadata_Column_RESTInterface>(sdt.gxTpr_Columns);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Columns);
			}
		}

		[DataMember(Name="ActionGroups", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtK2BT_ExtendedGridMetadata_ActionGroup_RESTInterface> gxTpr_Actiongroups
		{
			get {
				if (sdt.ShouldSerializegxTpr_Actiongroups_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtK2BT_ExtendedGridMetadata_ActionGroup_RESTInterface>(sdt.gxTpr_Actiongroups);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Actiongroups);
			}
		}

		[DataMember(Name="ColumnGroups", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtK2BT_ExtendedGridMetadata_ColumnGroup_RESTInterface> gxTpr_Columngroups
		{
			get {
				if (sdt.ShouldSerializegxTpr_Columngroups_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtK2BT_ExtendedGridMetadata_ColumnGroup_RESTInterface>(sdt.gxTpr_Columngroups);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Columngroups);
			}
		}

		[DataMember(Name="OverflowActionPosition", Order=3)]
		public  string gxTpr_Overflowactionposition
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Overflowactionposition);

			}
			set { 
				 sdt.gxTpr_Overflowactionposition = value;
			}
		}

		[DataMember(Name="RowSelectionFlagColumnName", Order=4)]
		public  string gxTpr_Rowselectionflagcolumnname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Rowselectionflagcolumnname);

			}
			set { 
				 sdt.gxTpr_Rowselectionflagcolumnname = value;
			}
		}


		#endregion

		public SdtK2BT_ExtendedGridMetadata sdt
		{
			get { 
				return (SdtK2BT_ExtendedGridMetadata)Sdt;
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
				sdt = new SdtK2BT_ExtendedGridMetadata() ;
			}
		}
	}
	#endregion
}