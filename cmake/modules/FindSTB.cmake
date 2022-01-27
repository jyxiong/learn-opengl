# locate the stb library.
#
# This module defines the following variables:
#
# STB_INCLUDE_DIR - where to find glm/glm.hpp
# STB_FOUND - if the library was successfully located

set(STB_HEADER_SEARCH_DIRS
        ${CMAKE_SOURCE_DIR}/3rdparty/stb
        )
find_path(STB_INCLUDE_DIR NAMES glm/glm.hpp
        PATHS ${GLM_HEADER_SEARCH_DIRS})

include(FindPackageHandleStandardArgs)
find_package_handle_standard_args(STB DEFAULT_MSG
        STB_INCLUDE_DIR
        )