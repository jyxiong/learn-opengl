# locate the assimp library
#
# This module defines the following variables:
#
# ASSIMP_FOUND - system has Assimp
# ASSIMP_INCLUDE_DIR - the Assimp include directories
# ASSIMP_LIBRARY - link these to use Assimp

# search for include
set(ASSIMP_HEADER_SEARCH_DIRS
    ${CMAKE_SOURCE_DIR}/3rdparty/assimp/include
)
find_path(ASSIMP_INCLUDE_DIR NAMES assimp/mesh.h
    PATHS ${ASSIMP_HEADER_SEARCH_DIRS})
# add assimp/config.h
set(ASSIMP_INCLUDE_DIR
    ${ASSIMP_INCLUDE_DIR}
    ${CMAKE_SOURCE_DIR}/3rdparty/assimp/build/include
)

# search for the library
set(ASSIMP_LIB_SEARCH_DIRS
    ${CMAKE_SOURCE_DIR}/3rd_party/assimp/build/bin
)
find_library(ASSIMP_LIBRARY NAMES assimp 
    PATHS ${ASSIMP_LIB_SEARCH_DIRS})

# set ASSIMP package
include(FindPackageHandleStandardArgs)
find_package_handle_standard_args(ASSIMP DEFAULT_MSG
    ASSIMP_LIBRARY ASSIMP_INCLUDE_DIR
)