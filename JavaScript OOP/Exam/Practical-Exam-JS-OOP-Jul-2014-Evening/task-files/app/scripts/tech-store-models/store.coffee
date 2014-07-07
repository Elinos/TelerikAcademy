define ['tech-store-models/item'], (Item) ->
  'use strict'
  class Store
    constructor: (name) ->
      if 6 <= name.length <= 30 then @name = name else throw new Error("Incorect length of name!")
      @_items = []

    _checkIfPartOfString: (stringOne, stringTwo) ->
      strOneToLower = stringOne.toLowerCase()
      strTwoToLower = stringTwo.toLowerCase()
      (strOneToLower.indexOf strTwoToLower) >= 0

    _sortLex: (prop) ->
      (a,b) ->
        a[prop].localeCompare b[prop]

    _filterByType: (typeOne, typeTwo) ->
      items = @_items[..]
      if typeTwo?
        itemsByType = (item for item in items when item.type is typeOne or item.type is typeTwo)
      else
        itemsByType = (item for item in items when item.type is typeOne)

    addItem: (item) ->
      throw new Error "You can add only items!" if item not instanceof Item
      @_items.push item
      this

    getAll: ->
      items = @_items[..]
      items.sort @_sortLex 'name'

    getSmartPhones: ->
      onlySmartPhones = @_filterByType 'smart-phone'
      onlySmartPhones.sort @_sortLex 'name'

    getMobiles: ->
      onlyMobiles = @_filterByType 'smart-phone', 'tablet'
      onlyMobiles.sort @_sortLex 'name'

    getComputers: ->
      onlyComputers = @_filterByType 'pc', 'notebook'
      onlyComputers.sort @_sortLex 'name'

    filterItemsByType: (type) ->
      filteredByType = @_filterByType type
      filteredByType.sort @_sortLex 'name'

    filterItemsByPrice: (options) ->
      if options?
        if options.min? then min = options.min else min = 0
        if options.max? then max = options.max else max = Number.POSITIVE_INFINITY
      else
        min = 0
        max = Number.POSITIVE_INFINITY

      items = @_items[..]
      itemsByPrice = (item for item in items when min <= item.price <= max)
      itemsByPrice.sort (itemOne, itemTwo) -> itemOne.price - itemTwo.price

    countItemsByType: ->
      items = @_items[..]
      countItemsByType = []
      for item in items
        if countItemsByType[item.type]
          countItemsByType[item.type]++
        else
          countItemsByType[item.type] = 1
      countItemsByType

    filterItemsByName: (partOfName) ->
      items = @_items[..]
      filteredByName = (item for item in items when @_checkIfPartOfString item.name, partOfName)
      filteredByName. sort @_sortLex 'name'
  Store
