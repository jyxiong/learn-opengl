cmake_minimum_required(VERSION 3.16)

project(3.1.2.shadow_mapping_base)

set(TARGET ${CHAPTER}_${PROJECT_NAME})
add_executable(${TARGET} shadow_mapping_base.cpp)
target_link_libraries(${TARGET} PUBLIC
        learnopengl
        glad
        glfw
        stb
        glm
        )
