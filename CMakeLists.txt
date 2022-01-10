cmake_minimum_required(VERSION 3.16)

project (LearnOpenGL)

set(CMAKE_CXX_STANDARD 11)

set(CMAKE_MODULE_PATH ${CMAKE_MODULE_PATH} "${CMAKE_SOURCE_DIR}/cmake/modules/")

# find glad
find_package(GLAD)
if(GLAD_FOUND)
    message(STATUS "GLAD found: " ${GLAD_INCLUDE_DIR})
else()
    message("GLAD not found")
endif()

# find glfw
find_package(GLFW3)
if(GLFW3_FOUND)
    message(STATUS "GLFW3 found: " ${GLFW3_INCLUDE_DIR})
else()
    message("GLFW3 not found")
endif()

# find glm
find_package(GLM REQUIRED)
if(GLM_FOUND)
    message(STATUS "GLM found: " ${GLM_INCLUDE_DIR})
else()
    message("GLM not found")
endif()

# find assimp
find_package(ASSIMP REQUIRED)
if(ASSIMP_FOUND)
    message(STATUS "ASSIMP found: " ${ASSIMP_INCLUDE_DIR})
else()
    message("ASSIMP not found")
endif()

# find other lib on macos
find_library(COCOA_LIBRARY Cocoa)
find_library(OpenGL_LIBRARY OpenGL)
find_library(IOKit_LIBRARY IOKit)
find_library(CoreVideo_LIBRARY CoreVideo)
set(APPLE_LIBRARIES ${COCOA_LIBRARY} ${IOKit_LIBRARY} ${OpenGL_LIBRARY} ${CoreVideo_LIBRARY})

add_subdirectory(src/1.getting_started)