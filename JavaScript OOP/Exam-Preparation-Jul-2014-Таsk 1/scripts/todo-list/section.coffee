define ['todo-list/item'], (Item) ->
  'use strict'
  class Section
    constructor: (@title) ->
      @items = []
    add: (item) ->
      throw new Error "You can add only items!" if item not instanceof Item
      @items.push item
      this
    getData: () ->
      sectionItems = (item.getData for item in @items)
      title: @title
      items: sectionItems
  Section
