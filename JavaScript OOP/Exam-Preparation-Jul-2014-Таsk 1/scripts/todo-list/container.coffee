define ['todo-list/section'], (Section) ->
  'use strict'
  class Container
    constructor: () ->
      @sections = []
    add: (section) ->
      throw new Error "You can add only sections!" if section not instanceof Section
      @sections.push section
      @
    getData: () ->
      containerSections = (section.getData for section in @sections)
      @sections
    Container
