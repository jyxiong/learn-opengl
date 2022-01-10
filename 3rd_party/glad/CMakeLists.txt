
cmake_minimum_required(VERSION 3.10)

project(glad VERSION 3.3)

add_library(glad STATIC
    ${CMAKE_SOURCE_DIR}/src/glad.c
    ${CMAKE_SOURCE_DIR}/include/glad/glad.h
)

target_include_directories(glad PUBLIC
    ${CMAKE_SOURCE_DIR}/include
)