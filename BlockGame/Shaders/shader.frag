#version 330

in vec2 vTextureCoord;

out vec4 outputColor;

uniform sampler2D Texture0;

void main()
{
    outputColor = texture(Texture0, vTextureCoord);
}