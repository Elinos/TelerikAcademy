// Generated by CoffeeScript 1.7.1
define(['todo-list/section'], function(Section) {
  'use strict';
  var Container;
  return Container = (function() {
    function Container() {
      this.sections = [];
    }

    Container.prototype.add = function(section) {
      if (!(section instanceof Section)) {
        throw new Error("You can add only sections!");
      }
      this.sections.push(section);
      return this;
    };

    Container.prototype.getData = function() {
      var containerSections, section;
      containerSections = (function() {
        var _i, _len, _ref, _results;
        _ref = this.sections;
        _results = [];
        for (_i = 0, _len = _ref.length; _i < _len; _i++) {
          section = _ref[_i];
          _results.push(section.getData);
        }
        return _results;
      }).call(this);
      return this.sections;
    };

    Container;

    return Container;

  })();
});

//# sourceMappingURL=container.map
