cmake_minimum_required(VERSION 3.16)

project(3.2.blending_sort)

set(TARGET ${CHAPTER}_${PROJECT_NAME})
add_executable(${TARGET} blending_sorted.cpp)
target_link_libraries(${TARGET} PUBLIC
        learnopengl
        glad
        glfw
        stb
        glm
        )