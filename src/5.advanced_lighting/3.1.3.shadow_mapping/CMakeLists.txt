cmake_minimum_required(VERSION 3.16)

project(3.1.3.shadow_mapping)

set(TARGET ${CHAPTER}_${PROJECT_NAME})
add_executable(${TARGET} shadow_mapping.cpp)
target_link_libraries(${TARGET} PUBLIC
        learnopengl
        glad
        glfw
        stb
        glm
        )
