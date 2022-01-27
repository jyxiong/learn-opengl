# locate the glm library.
#
# This module defines the following variables:
#
# GLM_INCLUDE_DIR - where to find glm/glm.hpp
# GLM_FOUND - if the library was successfully located

# search for include
set(GLM_HEADER_SEARCH_DIRS
    ${CMAKE_SOURCE_DIR}/3rdparty/glm
)
find_path(GLM_INCLUDE_DIR NAMES glm/glm.hpp
    PATHS ${GLM_HEADER_SEARCH_DIRS})

include(FindPackageHandleStandardArgs)
find_package_handle_standard_args(GLM DEFAULT_MSG
    GLM_INCLUDE_DIR
)
