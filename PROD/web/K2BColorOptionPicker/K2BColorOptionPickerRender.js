function K2BColorOptionPicker() {
  this.control = null;
  this.colorOptions = {};

  this.SetOptions = function (value) {
    this.colorOptions = value;
    if (this.control != null) {
      this.control.colorOptions = this.colorOptions;
    }
  };

  // Databinding for property Attribute
  this.SetAttribute = function (data) {
    ///UserCodeRegionStart:[SetAttribute] (do not remove this comment.)
    this.selectedIds = data;
    this.setControlValue();
    ///UserCodeRegionEnd: (do not remove this comment.)
  };

  // Databinding for property Attribute
  this.GetAttribute = function () {
    ///UserCodeRegionStart:[GetAttribute] (do not remove this comment.)
    return this.control != null && this.control.selectedIds.length > 0 ? this.control.selectedIds[0] : '';
    ///UserCodeRegionEnd: (do not remove this comment.)
  };

  this.show = function () {
    var container = document.getElementById(this.ContainerName);
    if (this.control == null) {
      this.control = document.createElement('k2bt-base-color-picker');
      this.control.colorOptions = this.colorOptions;
      this.control.maxSelectionSize = 1;
      this.control.enabled = this.Enabled;
      this.control.containerclass = this.ContainerClass;

      container.appendChild(this.control);

      this.setControlValue();

      var uc = this;
      this.control.addEventListener('selectionChanged', function () {
        uc.oninput();
        uc.onchange();

        if (uc.ControlValueChanged) {
          uc.ControlValueChanged();
        }
      });
    }
    this.control.enabled = this.Enabled;
    k2btools.updateFormControlVisibility(container, this.Visible);
  };

  this.setControlValue = function () {
    if (this.control != null) {
      if (this.selectedIds != null && this.selectedIds !== '' && this.selectedIds !== undefined) this.control.selectedIds = [this.selectedIds];
      else this.control.selectedIds = [];
    }
  };
}
