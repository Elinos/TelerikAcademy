// Generated by CoffeeScript 1.7.1
define([], function() {
  'use strict';
  var Item;
  Item = (function() {
    function Item(type, name, price) {
      var _ref;
      if (type === 'accessory' || type === 'smart-phone' || type === 'notebook' || type === 'pc' || type === 'tablet') {
        this.type = type;
      } else {
        throw new Error("Invalid item type!");
      }
      if ((6 <= (_ref = name.length) && _ref <= 40)) {
        this.name = name;
      } else {
        throw new Error("Incorect length of name!");
      }
      if (typeof price === 'number' && isFinite(price)) {
        this.price = price;
      } else {
        throw new Error("Invalid price!");
      }
    }

    return Item;

  })();
  return Item;
});

//# sourceMappingURL=item.map
