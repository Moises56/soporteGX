function K2BToggleBar() {
  this.control = null;
  this.Values = null;
  this.data = null;

  // Databinding for property Attribute
  this.SetAttribute = function (data) {
    ///UserCodeRegionStart:[SetAttribute] (do not remove this comment.)
    if (this.control != null) this.control.value = [data];
    this.data = data;
    ///UserCodeRegionEnd: (do not remove this comment.)
  };

  // Databinding for property Attribute
  this.GetAttribute = function () {
    ///UserCodeRegionStart:[GetAttribute] (do not remove this comment.)
    return this.data;

    ///UserCodeRegionEnd: (do not remove this comment.)
  };

  this.SetValues = function (v) {
    this.Values = v;
    if (this.control != null) this.control.values = this.Values;
  };

  this.SetValue = function (v) {
    this.SetAttribute(v);

    if (uc.ControlValueChanged) {
      uc.ControlValueChanged();
    }
  };

  this.show = function () {
    var uc = this;
    var container = document.getElementById(this.ContainerName);
    if (this.control == null || this.control.length === 0) {
      // Only create control once
      this.control = document.createElement('k2bt-toggle-bar');
      this.control.values = this.Values;
      this.control.value = [this.data];

      this.control.addEventListener('change', function () {
        var value;
        if (uc.control.value != null && uc.control.value.length > 0) value = uc.control.value[0];
        else value = null;

        uc.SetAttribute(value);

        uc.onchange();

        if (uc.ControlValueChanged) {
          uc.ControlValueChanged();
        }
      });

      this.control.addEventListener('newRecordClicked', function () {
        if (uc.CreateItem) {
          uc.CreateItem();
        }
      });

      this.control.addEventListener('input', function () {
        var value;
        if (uc.control.value != null && uc.control.value.length > 0) value = uc.control.value[0];
        else value = null;

        uc.SetAttribute(value);
        uc.oninput();
      });

      this.control.addEventListener('focus', this.onfocus.closure(this));
      container.appendChild(this.control);
    }

    this.control.includeemptyitem = this.IncludeEmptyItem;
    this.control.enabled = this.Enabled;
    this.control.togglestyle = this.ToggleStyle;
    this.control.readonlyclass = this.Class.split(' ')
      .map(s => 'Readonly' + s)
      .join(' ');

    this.control.emptyitemtext = k2btools.getTranslatedMessage(k2btools.resolveValue(this.EmptyItemText, 'GX_EmptyItemText'));
    this.control.noresultsfoundtext = k2btools.getTranslatedMessage(k2btools.resolveValue(this.NoResultsFoundText, 'K2BT_NoItems'));
    k2btools.updateFormControlVisibility(container, this.Visible);
  };
}
