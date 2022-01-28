cmake_minimum_required(VERSION 3.16)

project(4.1.textures)

set(TARGET ${CHAPTER}_${PROJECT_NAME})
file(GLOB SOURCE *.h *.cpp)
add_executable(${TARGET} ${SOURCE})

target_link_libraries(${TARGET} PUBLIC
        ${GLAD_LIBRARY}
        ${GLFW3_LIBRARY}
        ${APPLE_LIBRARIES}
        )
target_include_directories(${TARGET} PUBLIC
        ${GLAD_INCLUDE_DIR}
        ${GLFW3_INCLUDE_DIR}
        ${STB_INCLUDE_DIR}
        ${CMAKE_SOURCE_DIR}/includes
        ${CMAKE_BINARY_DIR}/configuration
        )
target_compile_definitions(${TARGET} PUBLIC
        STB_IMAGE_IMPLEMENTATION
        )

# copy shader files to build directory
file(GLOB SHADERS *.vs *.fs)
foreach(SHADER ${SHADERS})
    file(COPY ${SHADER} DESTINATION ${CMAKE_BINARY_DIR}/src/${CHAPTER}/${PROJECT_NAME})
endforeach(SHADER)