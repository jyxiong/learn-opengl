cmake_minimum_required(VERSION 3.16)

project (LearnOpenGL)

set(CMAKE_CXX_STANDARD 17)

configure_file(configuration/root_directory.h.in configuration/root_directory.h)
set(CMAKE_MODULE_PATH ${PROJECT_SOURCE_DIR}/cmake)
include(learnopengl)
include_directories(${CMAKE_BINARY_DIR}/configuration)

add_subdirectory(3rdparty)

add_subdirectory(src/1.getting_started)
add_subdirectory(src/4.advanced_opengl)
add_subdirectory(src/5.advanced_lighting)