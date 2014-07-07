define [], () ->
  'use strict'
  class Item
    constructor: (type, name, price) ->
      if type is 'accessory' or type is 'smart-phone' or
         type is 'notebook' or type is 'pc' or
         type is 'tablet'
        @type = type
      else
        throw new Error("Invalid item type!")

      if 6 <= name.length <= 40 then @name = name else throw new Error("Incorect length of name!")

      if typeof price is 'number' and isFinite(price)
        @price = price
      else
        throw new Error("Invalid price!")
  Item
